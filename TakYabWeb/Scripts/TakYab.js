
function selectThis(itemId, dropDownId, hiddenControlId, itemName) {

    if (dropDownId != "") {
        $("#" + dropDownId + " .title").html(itemName);
        $("#" + dropDownId + " .title").attr("selectedValue", itemId);
        $("#" + hiddenControlId).val(itemId);

        if (itemId == "") {
            $("#" + dropDownId).removeClass("selectedButton");
        }
        else {
            $("#" + dropDownId).addClass("selectedButton");
        }
    }
    updateDropDowns();
}

function resetSearch() {
    $('input[name=carStatusHidden]').val(['-1']);

    selectThis('', 'provinceDropDownMenu', 'provinceHidden', 'همه');
    selectThis('', 'modelDropDownMenu', 'modelHidden', 'همه');
    selectThis('', 'subModelDropDownMenu', 'subModelHidden', 'همه');
    selectThis('', 'priceRangeDropDownMenu', 'priceRangeHidden', 'همه');
    selectThis('', 'buildYearDropDownMenu', 'buildYearHidden', 'همه');
    selectThis('', 'adTypeDropDownMenu', 'adTypeHidden', 'همه');
    updateDropDowns();

    //var loc = String(window.location);
    //var n = loc.indexOf("Search/SearchResults");


    //if (n > 0) {
    //    window.location = "/Search/Search/SearchResults";
    //}
    //else
    //    window.location.reload();
}



function updateDropDowns() {
    var carStatus = $('input[name=carStatusHidden]:checked').val();
    if (carStatus == "-1")
        carStatus = "";

    $.ajax({
        url: '/Search/Search/SearchComponentNewJson',
        type: 'post',
        data: JSON.stringify({
            CarStatusString: $('input[name=carStatusHidden]:checked').val(),
            ProvinceString: $("#provinceHidden").val(),
            ModelString: $("#modelHidden").val(),
            SubModelString: $("#subModelHidden").val(),
            PriceRangeString: $("#priceRangeHidden").val(),
            BuildYearString: $("#buildYearHidden").val(),
            AdTypeIdString: $("#adTypeHidden").val(),
        }),
        dataType: "json",
        processData: false,
        contentType: "application/json; charset=utf-8",
        success: function (data) { SuccessRoleChangeHandler(data); }
    });


}


function SuccessRoleChangeHandler(data) {
    var searcResult = data.Result;


    var provinceDropDownHTML =
             '<li role="presentation"><a role="menuitem" tabindex="-1" href="#" onclick="selectThis(\'\', \'provinceDropDownMenu\', \'provinceHidden\', \'همه\');return false;">همه</a></li>';
    for (var i = 0; searcResult.ProvinceSearchCriteriaItemList != null && i < searcResult.ProvinceSearchCriteriaItemList.length; i++) {
        var item = searcResult.ProvinceSearchCriteriaItemList[i];
        provinceDropDownHTML += '<li role="presentation"><a role="menuitem" tabindex="-1" href="#" onclick="selectThis(\'' + item.ItemId + '\',\'provinceDropDownMenu\',\'provinceHidden\',\'' + item.Name + '\');return false;">' + item.Name + ' (' + item.Count + ')</a></li>';
    }
    $("#provinceDropDownMenuUL").html(provinceDropDownHTML);


    var modelDropDownHTML =
             '<li role="presentation"><a role="menuitem" tabindex="-1" href="#" onclick="selectThis(\'\', \'modelDropDownMenu\', \'modelHidden\', \'همه\');return false;">همه</a></li>';
    for (var i = 0; searcResult.ModelSearchCriteriaItemList != null && i < searcResult.ModelSearchCriteriaItemList.length; i++) {
        var item = searcResult.ModelSearchCriteriaItemList[i];
        modelDropDownHTML += '<li role="presentation"><a role="menuitem" tabindex="-1" href="#" onclick="selectThis(\'' + item.ItemId + '\',\'modelDropDownMenu\',\'modelHidden\',\'' + item.Name + '\');return false;">' + item.Name + ' (' + item.Count + ')</a></li>';
    }
    $("#modelDropDownMenuUL").html(modelDropDownHTML);



    var subModelDropDownHTML =
     '<li role="presentation"><a role="menuitem" tabindex="-1" href="#" onclick="selectThis(\'\', \'subModelDropDownMenu\', \'subModelHidden\', \'همه\');return false;">همه</a></li>';
    for (var i = 0; searcResult.SubModelSearchCriteriaItemList != null && i < searcResult.SubModelSearchCriteriaItemList.length; i++) {
        var item = searcResult.SubModelSearchCriteriaItemList[i];
        subModelDropDownHTML += '<li role="presentation"><a role="menuitem" tabindex="-1" href="#" onclick="selectThis(\'' + item.ItemId + '\',\'subModelDropDownMenu\',\'subModelHidden\',\'' + item.Name + '\');return false;">' + item.Name + ' (' + item.Count + ')</a></li>';
    }
    $("#subModelDropDownMenuUL").html(subModelDropDownHTML);


    var priceRangeDropDownHTML =
     '<li role="presentation"><a role="menuitem" tabindex="-1" href="#" onclick="selectThis(\'\', \'priceRangeDropDownMenu\', \'priceRangeHidden\', \'همه\');return false;">همه</a></li>';
    for (var i = 0; searcResult.PriceRangeSearchCriteriaItemList != null && i < searcResult.PriceRangeSearchCriteriaItemList.length; i++) {
        var item = searcResult.PriceRangeSearchCriteriaItemList[i];
        priceRangeDropDownHTML += '<li role="presentation"><a role="menuitem" tabindex="-1" href="#" onclick="selectThis(\'' + item.ItemId + '\',\'priceRangeDropDownMenu\',\'priceRangeHidden\',\'' + item.Name + '\');return false;">' + item.Name + ' (' + item.Count + ')</a></li>';
    }
    $("#priceRangeDropDownMenuUL").html(priceRangeDropDownHTML);


    var buildYearDropDownHTML =
     '<li role="presentation"><a role="menuitem" tabindex="-1" href="#" onclick="selectThis(\'\', \'buildYearDropDownMenu\', \'buildYearHidden\', \'همه\');return false;">همه</a></li>';
    for (var i = 0; searcResult.BuildYearSearchCriteriaItemList != null && i < searcResult.BuildYearSearchCriteriaItemList.length; i++) {
        var item = searcResult.BuildYearSearchCriteriaItemList[i];
        buildYearDropDownHTML += '<li role="presentation"><a role="menuitem" tabindex="-1" href="#" onclick="selectThis(\'' + item.ItemId + '\',\'buildYearDropDownMenu\',\'buildYearHidden\',\'' + item.Name + '\');return false;">' + item.Name + ' (' + item.Count + ')</a></li>';
    }
    $("#buildYearDropDownMenuUL").html(buildYearDropDownHTML);


    var adTypeDropDownHTML =
     '<li role="presentation"><a role="menuitem" tabindex="-1" href="#" onclick="selectThis(\'\', \'adTypeDropDownMenu\', \'adTypeHidden\', \'همه\');return false;">همه</a></li>';
    for (var i = 0; searcResult.AdTypeSearchCriteriaItemList != null && i < searcResult.AdTypeSearchCriteriaItemList.length; i++) {
        var item = searcResult.AdTypeSearchCriteriaItemList[i];
        adTypeDropDownHTML += '<li role="presentation"><a role="menuitem" tabindex="-1" href="#" onclick="selectThis(\'' + item.ItemId + '\',\'adTypeDropDownMenu\',\'adTypeHidden\',\'' + item.Name + '\');return false;">' + item.Name + ' (' + item.Count + ')</a></li>';
    }
    $("#adTypeDropDownMenuUL").html(adTypeDropDownHTML);


    $("#totalNumberofCars").html(searcResult.TotalNumberofCars);
}





function showRequiredLogin(element) {
    var newElement = '<div class="alert alert-danger loginAlert" role="alert"><a href="#" class="alert-link">وارد سیستم شوید!</a></div>';
    $(element).parent().append($(newElement));
    setTimeout(function () { $(".alert").addClass("hideAlert"); }, 1000);
}


function addtoFavourits(element, carId) { 
    $.ajax({
        url: '/Ads/Car/AddToFavouriteCars',
        type: 'post',
        data: JSON.stringify({
            CarId: carId
        }),
        dataType: "json",
        processData: false,
        contentType: "application/json; charset=utf-8"
    });

    var newElement = '<div class="alert alert-success loginAlert" role="alert" style="display:inline-block;position:absolute;top:0;right:10;"><a href="#" class="alert-link">اضافه شد!</a></div>';
    $(element).parent().append($(newElement));
    setTimeout(function () { $(".alert").addClass("hideAlert"); }, 1000);
}




function addtoFirstPage(element, carId) { 
    $.ajax({
        url: '/Admin/Admin/AddToFirstPageAds',
        type: 'post',
        data: JSON.stringify({
            CarId: carId
        }),
        dataType: "json",
        processData: false,
        contentType: "application/json; charset=utf-8"
    });

    var newElement = '<div class="alert alert-success" role="alert"><a href="#" class="alert-link">اضافه شد!</a></div>';
    $(element).html(newElement); 
}


function addtoCompareCars(carId) {

}

function approveAd(carId, element) {
    $.ajax({
        url: '/Admin/Admin/ConfirmAdJson',
        type: 'post',
        data: JSON.stringify({
            CarId: carId
        }),
        dataType: "json",
        processData: false,
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            $(element).parent().parent().removeClass("CarNew");
        }
    });
}

