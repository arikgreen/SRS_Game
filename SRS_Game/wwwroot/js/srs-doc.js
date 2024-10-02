function addSection(sectionId) {
    const zeroPad = (num, places) => String(num).padStart(places, '0');

    var btnId = "#add-" + sectionId;
    var itemsCount = parseInt($(btnId).attr("data-count"));

    var newItemsCount = itemsCount + 1;

    $(btnId).attr("data-count", newItemsCount.toString());

    var newId = sectionId + "_" + zeroPad(newItemsCount, 3);
    var refText = sectionId.toUpperCase() + "_" + zeroPad(newItemsCount, 3);

    var blankId = "#" + sectionId + "-000";
    var cloned = $(blankId).clone().prop('id', newId);

    var appendTo = "#" + sectionId + " .tables";
    cloned.appendTo(appendTo);

    // Update ids and names for new element.
    $("#" + newId + " .form-control").each(function () {
        // id = Model_SRS_Stakeholders_0__Reference
        // name = Model.SRS.Stakeholders[0].Reference

        //let name = /__(\w+)$/.exec(this.id);

        if ($(this).hasClass("ref"))
            this.value = refText;

        this.id = this.id.replace("_0__", "_" + itemsCount + "__");
        this.name = this.name.replace("[0]", "[" + itemsCount + "]");
        //}
    });

    // Remove section from SRS doc
    $("i.bi-trash").on("click", function () {
        var ref = $(this).attr("data-ref");

        var btnId = "#add-" + ref;

        var itemsCount = parseInt($(btnId).attr("data-count"));

        $(btnId).attr("data-count", itemsCount);

        $(this).parent().parent().remove();
    });
}

$("#srs-header").on("click", function () {
    console.log("aaaa" + $("#srs-submit").attr("form"));
    $("#srs-submit").attr("form", "srs-header-form")
});

$("#srs-body").on("click", function () {
    console.log("bbbb" + $("#srs-submit").attr("form"));
    $("#srs-submit").attr("form", "srs-doc-form")
});
