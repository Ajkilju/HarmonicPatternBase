// Write your Javascript code.

$('#advencedOptionsTriggerUp').on('click', function () {  
    $('#advencedOptions').slideUp(500);
    $('#advencedOptionsTriggerUp').hide();
    $('#advencedOptionsTriggerDown').show();
})

$('#advencedOptionsTriggerDown').on('click', function () {
    $('#advencedOptions').slideDown(500);
    $('#advencedOptionsTriggerDown').hide();
    $('#advencedOptionsTriggerUp').show();
})

