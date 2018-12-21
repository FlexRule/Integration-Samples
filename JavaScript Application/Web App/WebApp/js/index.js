angular
	.module('MyApp', ['ngMaterial', 'ngMessages', 'material.svgAssetsCache'])
	.controller('DemoCtrl', function ($scope) {

	    var statesRules = FlexRule.RuntimeEngine.fromJavaScript("SampleUI.BusinessLogic", "States");
	    var submitRules = FlexRule.RuntimeEngine.fromJavaScript("SampleUI.BusinessLogic", "Form Val");

	    $scope.form = {
	        country: null,
	        state: null,
	        name: null,
	        family: null,
	        birthday: null,
	        email: null,
            errors:null
	    };


	    $scope.countries = [
			{ key: 0, value: '-- Select Country --' },
			{ key: 1, value: 'Australia' },
			{ key: 2, value: 'New Zealand' },
	    ];

	    $scope.states = [
	    ];

	    $scope.submit = function () {
	        var form = $scope.form;
	        console.log('Submit clicked = ', form);
	        var res = submitRules.run(form);
	        form.errors = [];
	        var notices = res.context.notifications.default.notices;
	        for (var i = 0; i < notices.length; i++) {
	            form.errors.push(notices[i]);
	        }
	    };

	    $scope.updateStates = function () {
	        var country = $scope.form.country;

            // call to rule engine
	        var result = statesRules.run(country);
            // get the output parameter of the rule which is the list of states for the country
	        var states = result.context.variableContainer.states;
            // we update based on the UI rules result
	        $scope.states = states;
	    }
    })
	.config(function ($mdThemingProvider) {

	    // Configure a dark theme with primary foreground yellow

	    $mdThemingProvider.theme('docs-dark', 'default')
			.primaryPalette('yellow')
			.dark();

	});


/**
 Copyright 2016 Google Inc. All Rights Reserved.
 Use of this source code is governed by an MIT-style license that can be foundin the LICENSE file at http://material.angularjs.org/HEAD/license.
 **/