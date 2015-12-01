// For an introduction to the Blank template, see the following documentation:
// http://go.microsoft.com/fwlink/?LinkID=392286
(function () {
    "use strict";

    var app = WinJS.Application;
    var activation = Windows.ApplicationModel.Activation;

    app.onactivated = function (args) {
        if (args.detail.kind === activation.ActivationKind.launch) {
            if (args.detail.previousExecutionState !== activation.ApplicationExecutionState.terminated) {
                // TODO: This application has been newly launched. Initialize
                // your application here.
                args.setPromise(WinJS.xhr({ url: "http://localhost:2985/api/products" }).done(function (data) {
                    if (data.status === 200) {
                        var products = JSON.parse(data.responseText);
                        var productList = new WinJS.Binding.List(products);
                        var listView = document.getElementById('tempListView').winControl;
                        listView.itemDataSource = productList.dataSource;
                        //var select = document.getElementById('tempSelect').winControl;
                        //select.data = productList;
                    }
                }));
            } else {
                // TODO: This application was suspended and then terminated.
                // To create a smooth user experience, restore application state here so that it looks like the app never stopped running.
            }

            args.setPromise(WinJS.UI.processAll());
        }
    };

    function showAlert() {
        var dialog = Windows.UI.Popups.MessageDialog("Toggle, toggle...", "You Did A Thing!");
        dialog.commands.append(new Windows.UI.Popups.UICommand("OK", function (command) { }));
        dialog.showAsync();
    }

    app.oncheckpoint = function (args) {
        // TODO: This application is about to be suspended. Save any state
        // that needs to persist across suspensions here. You might use the
        // WinJS.Application.sessionState object, which is automatically
        // saved and restored across suspension. If you need to complete an
        // asynchronous operation before your application is suspended, call
        // args.setPromise().
    };

    app.start();
})();