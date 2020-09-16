// ползунок бюджета
if (document.getElementById('scale_budget')) {
    jQuery(document).ready(function ($) {
        $("#scale_budget").each(function () {
            let $this = $(this);
            let min = parseInt($this.data('min'));
            let max = parseInt($this.data('max'));

            $this.slider({
                animate: true,
                range: "min",
                value: 5,
                min: min,
                max: max,
                step: 5,
                slide: function (event, ui) {
                    $("#scale-budget_btn_dropdown").text(ui.value);
                    $("#scale-budget_input").val(ui.value);
                }
            });
        });
        $("#scale-budget_input").keyup(function () {
            let sum = $(this).val();
            if (sum < 5) sum = 5;
            if (sum > 3500) sum = 3500;
            $("#scale_budget").slider("value", sum);
            $("#scale-budget_btn_dropdown").text(sum);
        });
    });
}