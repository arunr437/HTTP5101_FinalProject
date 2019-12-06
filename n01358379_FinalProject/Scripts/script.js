window.onload = function () {
    var count = 0;

    $("#clickMe").click(changeFont);
    $("#clickMe").css("float", "right");
    $(".formHide").hide();
    $("#page_author").prop('required',false);

    $(".formAuthorList").change(function () {
        // Pure JS
        var selectedVal = this.value;


        if (selectedVal == "New") {
            $(".formHide").show("slow");
        }
        else {
            $(".formHide").hide();
        }
    });


    function changeFont() {
        count = count + 1;
        if (count % 5 == 0)
            $("body").css("font-family", "Georgia, serif");
        else if (count % 5 == 1)
            $("body").css("font-family", "'Comic Sans MS', cursive, sans-serif");
        else if (count % 5 == 2)
            $("body").css("font-family", "Arial, Helvetica, 'sans - serif'");
        else if (count % 5 == 3)
            $("body").css("font-family", "'Courier New', Courier, monospace");
        else if (count % 5 == 4)
            $("body").css("font-family", "Impact, Charcoal, 'sans - serif'");
    }

}