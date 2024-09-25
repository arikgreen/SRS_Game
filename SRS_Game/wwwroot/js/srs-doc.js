function addSection(sectionId) {
    const zeroPad = (num, places) => String(num).padStart(places, '0');

    var btnId = "#add-" + sectionId;
    var blankId = "#" + sectionId + "-000";
    var appendTo = "#" + sectionId + " .tables";

    var itemsCount = parseInt($(btnId).attr("data-count"));

    console.log(itemsCount);

    itemsCount += 1;

    var newId = sectionId + "-" + zeroPad(itemsCount, 3);
    var refText = sectionId.toUpperCase() + "_" + zeroPad(itemsCount, 3);

    var cloned = $(blankId).clone().prop('id', newId);
    cloned.appendTo(appendTo);

    $(btnId).attr("data-count", itemsCount.toString());

    newId = "#" + newId

    var refId = newId + " .ref";

    $(refId).text(refText);

    $(newId + " .form-control").each(function () {
        this.id = sectionId + "-" + this.id;
        this.name = sectionId + "-" + this.name;
    });
}

//$(document).ready(function () {

//});