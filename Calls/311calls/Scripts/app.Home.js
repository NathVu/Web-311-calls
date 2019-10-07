App.Home = {
    init: function () {

    },
    GetSet: function (itemChange) {
        var currentMax = $("#CurrentMax").val();
        if (Math.abs(itemChange) > currentMax) {
            alert("Displaying the full set of entries");
            return;
        }

        var currentFloor = $("#CurrentFloor").val();
        var currentCeil = $("#CurrentCeil").val();
        var activeSearch = $("#ActiveSearch").val();
        var searchString = $("#SearchString").val();
        

        $.post("~/Home/ChangeSet", {
            floor: currentFloor,
            ceil: currentCeil,
            max: currentMax,
            isActiveSearch: activeSearch,
            searchString: searchString,
            requestedChange: itemChange
        }, function (result) {
                if (result.Reroute) {
                    location.href.url = result.Url;
                }
                else {
                    alert("error changing data set")
                }
        });
    }
}