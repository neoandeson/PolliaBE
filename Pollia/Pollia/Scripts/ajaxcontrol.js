var searchValue;
var currentPos = 0;
var takeNum = 5;
var tripbook = new Map();
function searchByName() {
    searchValue = $("#searchValue").val();
    currentPos = 0;
    takeNum = 5;
    var resultElements = $("#resultElements");
    resultElements.empty();
    searchPlacesByName(searchValue, currentPos, takeNum);
    showResult();
    currentPos += takeNum;
}
function showMorePlace() {
    if (takeNum <= 0)
        return;
    searchPlacesByName(searchValue, currentPos, takeNum);
    currentPos += takeNum;
}

function addToTripBook(Id, Name, Longitude, Latitude) {
    tripbook.set(
        Id,
        {
            Id: Id,
            Name: Name,
            Pos: {
                lng: Longitude,
                lat: Latitude
            }
        }
    );

}

function searchPlacesByName(name, curr, take) {
    if (searchValue == null || searchValue.length == 0)
        return;
    $.ajax({
        url: "/api/Place/GetPlacesByName",
        method: "GET",
        data: { name: searchValue, curr: curr, take: take },
        success: function (data) {
            var list = data;
            var resultElements = $("#resultElements");
            if (list.length < takeNum) {
                takeNum = 0;
                $('#showMore').hide();
            } else {
                $('#showMore').show();
            }
            for (var i = 0; i < list.length; i++) {
                var json = list[i];
                var s = "";
                s += '<div class="resultElement clearfloat" onclick="showResultDetail();searchById(' + json.Id + ');">';
                s += '<div class="info" >';
                s += '<p class="header">' + json.Name + '</p>';
                s += '<p class="star">';
                s += '<span>' + json.RatingStar + '</span> ';
                for (var iStar = 0; iStar < json.RatingStar; iStar++)
                    s += '<i class="fa fa-star"></i>';
                for (var iStar = 0; iStar < 5 - json.RatingStar; iStar++)
                    s += '<i class="fa fa-star stargrey"></i>';
                s += '</p>';
                s += '<p>' + json.PlaceKind + '</p>';
                s += '<p>' + json.Address + '</p>';
                if (json.TimeOpen != null || json.TimeClose != null)
                    s += '<p>' +
                        ((json.TimeOpen != null) ? ('Open: ' + json.TimeOpen + ' -') : '') +
                        ((json.TimeClose != null) ? ('Close: ' + json.TimeClose) : '') +
                        '</p>';
                s += '</div >';
                s += '<div class="resultThumbnail" style="background-image: url(\'' + json.ImageUrl + '\')"></div>';
                s += '</div>';
                resultElements.append(s);
            }
        }
    });
}

function searchById(id) {
    $.ajax({
        url: "/api/Place/GetPlace/" + id,
        method: "GET",
        success: function (data) {
            var json = data;
            var resultDetail = $("#searchResultDetail");
            resultDetail.empty();
            var s = "";
            s += '<div class="resultCover">';
            s += '<div style="background-image: url(\'' + ((json.ImageUrl != null) ? json.ImageUrl : "") + '\')"></div >';
            s += '</div>';
            s += '<div class="resultHeader">';
            s += '<div class="info" >';
            s += '<p class="header">' + json.Name + '</p>';
            s += '<p class="star">';
            s += '<span>' + json.RatingStar + '</span> ';
            for (var iStar = 0; iStar < json.RatingStar; iStar++)
                s += '<i class="fa fa-star"></i>';
            for (var iStar = 0; iStar < 5 - json.RatingStar; iStar++)
                s += '<i class="fa fa-star stargrey"></i>';
            s += '</p>';
            s += '<p>' + json.PlaceKind + '</p>';
            s += '</div> <div class="addToTripbookContain">';
            s += '<div class="buttonCircle buttonPrimary" onclick="addToTripBook(\'' + json.Id + '\',\'' + json.Name.replace(/'/g, "\\'") + '\',' + json.Longitude + ',' + json.Latitude + ');showSearchDual();">';
            s += '<i class="fa fa-plus"></i>';
            s += '</div>';
            s += '</div></div>';
            s += '<div class="resultDetail">';
            s += '<p><i>' + json.Description + '</i></p>';
            s += '<p><span class="fa fa-location-arrow"></span> ' + json.Address + '</p>';
            s += (json.PhoneNumber != null) ? ('<p><span class="fa fa-phone"></span> ' + json.PhoneNumber + '</p>') : "";
            s += (json.Facebook != null) ? ('<p><span class="fa fa-facebook"></span> <a href="' + json.Facebook + '">' + json.Facebook + '</a></p>') : "";
            s += (json.Instagram != null) ? ('<p><span class="fa fa-instagram"></span> <a href="' + json.Instagram + '">' + json.Instagram + '</a></p>') : "";
            if (json.TimeOpen != null || json.TimeClose != null)
                s += '<p><span class="fa fa-clock-o"></span> ' +
                    ((json.TimeOpen != null) ? ('Open: ' + json.TimeOpen + ' -') : '') +
                    ((json.TimeClose != null) ? ('Close: ' + json.TimeClose) : '') +
                    '</p>';
            s += '</div >';
            s += '<div class="commentContain" id="commentContain"></div>';
            s += '</div>';
            resultDetail.append(s);
            deleteMarkers();
            addMarker({ lat: json.Latitude, lng: json.Longitude });
            showMarkers();
            map.setCenter({ lat: json.Latitude, lng: json.Longitude });
            map.setZoom(15);
        }
    });
}
