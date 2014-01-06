﻿/*jslint unparam: true, white: true, browser: true, devel: true */
/*global bettercms */

bettercms.define('bcms.languages', ['bcms.jquery', 'bcms', 'bcms.dynamicContent', 'bcms.siteSettings', 'bcms.ko.extenders', 'bcms.ko.grid', 'bcms.autocomplete'],
function ($, bcms, dynamicContent, siteSettings, ko, kogrid, autocomplete) {
    'use strict';

    var languages = {},
        selectors = {},
        links = {
            saveLanguageUrl: null,
            deleteLanguageUrl: null,
            loadLanguagesUrl: null,
            loadSiteSettingsLanguagesUrl: null,
            languageSuggestionUrl: null
        },
        globalization = {
            deleteLanguageConfirmMessage: null
        };

    /**
    * Assign objects to module.
    */
    languages.links = links;
    languages.globalization = globalization;

    /**
    * Language autocomplete list view model
    */
    var LanguageAutocompleteListViewModel = (function (_super) {
        bcms.extendsClass(LanguageAutocompleteListViewModel, _super);

        function LanguageAutocompleteListViewModel(onItemSelect) {
            var options = {
                serviceUrl: links.languageSuggestionUrl,
                onItemSelect: onItemSelect
            };

            _super.call(this, options);
        }
            
        return LanguageAutocompleteListViewModel;
    })(autocomplete.AutocompleteViewModel);

    /**
    * Languages list view model
    */
    var LanguagesListViewModel = (function(_super) {

        bcms.extendsClass(LanguagesListViewModel, _super);

        function LanguagesListViewModel(container, items, gridOptions) {
            _super.call(this, container, links.loadLanguagesUrl, items, gridOptions);
        }

        LanguagesListViewModel.prototype.createItem = function (item) {
            var newItem = new LanguageViewModel(this, item);
            return newItem;
        };

        return LanguagesListViewModel;

    })(kogrid.ListViewModel);

    /**
    * Language view model
    */
    var LanguageViewModel = (function(_super) {

        bcms.extendsClass(LanguageViewModel, _super);

        function LanguageViewModel(parent, item) {
            _super.call(this, parent, item);

            var self = this;

            self.hasCodeFocus = ko.observable(false);
            self.hasNameFocus = ko.observable(false);
            self.name = ko.observable().extend({ required: "", maxLength: { maxLength: ko.maxLength.name } });
            self.code = ko.observable().extend({ required: "", maxLength: { maxLength: ko.maxLength.name } });
            self.shortCode = ko.observable();
            self.oldAutocompleteValue = '';

            self.registerFields(self.name, self.code);

            self.name(item.Name);
            self.code(item.Code);

            self.autocompleteViewModel = new LanguageAutocompleteListViewModel(function (suggestionItem) {
                var name = self.name(),
                    suggestedName = suggestionItem.name();

                if (!name || self.oldAutocompleteValue == self.name()) {
                    self.name(suggestedName);
                }

                self.oldAutocompleteValue = suggestedName;
                self.shortCode(suggestionItem.id());
            });

            if (!self.isNew()) {
                self.code.editingIsDisabled = ko.observable(true);
                self.hasNameFocus(true);
            } else {
                self.hasCodeFocus(true);
            }
        }

        LanguageViewModel.prototype.getDeleteConfirmationMessage = function () {
            return $.format(globalization.deleteLanguageConfirmMessage, this.name());
        };

        LanguageViewModel.prototype.onAfterItemSaved = function (json) {
            _super.prototype.onAfterItemSaved.call(this, json);
            
            if (!this.code.editingIsDisabled) {
                this.code.editingIsDisabled = ko.observable(true);
                this.hasNameFocus(true);
            }
        };

        LanguageViewModel.prototype.getSaveParams = function () {
            var params = _super.prototype.getSaveParams.call(this);
            params.Name = this.name();
            params.Code = this.shortCode() || this.code();

            return params;
        };

        return LanguageViewModel;

    })(kogrid.ItemViewModel);

    /**
    * Initializes site settings languages grid
    */
    function initializeSiteSettingsLanguages(json) {
        var container = siteSettings.getMainContainer(),
            data = (json.Success == true) ? json.Data : {};

        var viewModel = new LanguagesListViewModel(container, data.Items, data.GridOptions);
        viewModel.deleteUrl = links.deleteLanguageUrl;
        viewModel.saveUrl = links.saveLanguageUrl;

        ko.applyBindings(viewModel, container.get(0));
    }

    /**
    * Loads site settings languages list.
    */
    languages.loadSiteSettingsLanguagesList = function() {
        dynamicContent.bindSiteSettings(siteSettings, links.loadSiteSettingsLanguagesUrl, {
            contentAvailable: initializeSiteSettingsLanguages
        });
    };

    /**
    * Initializes languages module.
    */
    languages.init = function() {
        bcms.logger.debug('Initializing bcms.languages module.');
    };

    /**
    * Register initialization
    */
    bcms.registerInit(languages.init);

    return languages;
});
