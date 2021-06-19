function attachEventsListeners() {

    document.getElementById('daysBtn').addEventListener('click', OnClickDays);
    document.getElementById('hoursBtn').addEventListener('click', OnClickHours);
    document.getElementById('minutesBtn').addEventListener('click', OnClickMinutes);
    document.getElementById('secondsBtn').addEventListener('click', OnClickSeconds);

    function OnClickDays() {

        let days = Number(document.getElementById('days').value);

        document.getElementById('hours').value = days * 24;
        document.getElementById('minutes').value = days * 1440;
        document.getElementById('seconds').value = days * 86400;
    }

    function OnClickHours() {

        let hours = Number(document.getElementById('hours').value);

        document.getElementById('days').value = hours / 24;
        document.getElementById('minutes').value = hours * 60;
        document.getElementById('seconds').value = hours * 3600;
    }

    function OnClickMinutes() {

        let minutes = Number(document.getElementById('minutes').value);

        document.getElementById('days').value = minutes / 1440;
        document.getElementById('hours').value = minutes / 60;
        document.getElementById('seconds').value = minutes * 60;
    }

    function OnClickSeconds() {

        let seconds = Number(document.getElementById('seconds').value);

        document.getElementById('days').value = seconds / 86400;
        document.getElementById('hours').value = seconds / 3600;
        document.getElementById('minutes').value = seconds / 60;
    }
}