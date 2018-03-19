var coverIndex = 3;

$(document).ready(function () {
    coverIndex = $('#slideContain').children().length - 1;
    document.addEventListener("scroll", headerControl);
    if (coverIndex >= 0){
        slideShow();
        slideInterval = setInterval(slideShow, 3000);
    }
})


function slideShow() {
    var tag = $('#slideContain');
    var listChild = tag.children();
    $(listChild[coverIndex]).animate({opacity: 0}, 1000, "swing");
    coverIndex = (coverIndex + 1) % listChild.length;
    $(listChild[coverIndex]).animate({opacity: 1}, 1000, "swing");
}

function headerControl() {
    if (window.pageYOffset <= 600)
        $('header')[0].style.backgroundColor = 'rgba(255,255,255,' + (0.4 + 0.5 * window.pageYOffset / 600) + ')';
}

function showResult() {
    $('#searchResultDetail').hide();
    $('#searchResult').fadeIn();
}

function showResultDetail() {
    $('#searchResult').hide();
    $('#searchResultDetail').fadeIn();
}

function showSearchDual() {
    $('#searchDual').fadeIn();
    var tripbookTag = $('#tripbook');
    tripbookTag.empty();
    var s = "";
    for (var [key, value] of tripbook) {
        s += '<div class="searchContainer clearfloat">';
        s += '<input type= "text" placeholder= "Ex: Pollia, Ho Chi Minh City, Vietnam" value= "'+value.Name+'" >';
        s += '<button style="float: right" onclick=""><i class="fa fa-times"></i></button>     ';
        s += '<button style="float: right" onclick=""><i class="fa fa-search"></i></button>    ';
        s += '</div >';
    }
    tripbookTag.append(s);
    if (tripbook.size >= 2) {
        calculateAndDisplayRoutes(tripbook);
    }
}


function closeSearchDual() {
    $('#searchDual').fadeOut();
    closeResult();
}
function backSearchDual() {
    $('#searchDual').fadeOut();
}

function closeResult() {
    $('#searchResult').fadeOut(100);
    $('#searchResultDetail').fadeOut(100);
}

function toggleTypeList(){
    if ($('#typeList').css("height") == '0px'){
        $('#typeList').css("height",  $('#typeList>ul').css("height"));
        $('#typeList>ul').css("transform", "translate(0,0)");
    } else {
        $('#typeList').css("height","0px");
        $('#typeList>ul').css("transform", "translate(0,-100%)");
    }
}
function closeTypeList() {
    $('#typeList').css("height","0px");
    $('#typeList>ul').css("transform", "translate(0,-100%)");
}
function changeSearchType(tag) {
    tag = $(tag);
    $("#searchType").html(tag.html());
}


function showPopup(id) {
    $("#" + id).fadeIn(100);
}
function closePopup(id) {
    $("#" + id).fadeOut(100);
}