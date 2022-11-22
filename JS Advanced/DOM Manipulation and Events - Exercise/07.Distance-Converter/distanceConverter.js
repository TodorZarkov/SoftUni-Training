function attachEventsListeners() {
    let inputDistEl = document.getElementById("inputDistance");
    let inputUnitEl = document.getElementById("inputUnits");
    let outputDistEl = document.getElementById("outputDistance");
    let outputUnitEl = document.getElementById("outputUnits");

    document.getElementById("convert").addEventListener('click', onConvert.bind(this));

    //CONTROL
    function onConvert() {
        outputDistEl.value = convert(inputDistEl.value, inputUnitEl.value, outputUnitEl.value);
        console.log("onConvert here")
    }



    //MODEL
    function convert(inputDist, inputUnit, outputUnit) {
        let result =
            Number(inputDist)
            * multiplierToMetersFrom(inputUnit)
            / multiplierToMetersFrom(outputUnit);
        return result;
    }

    function multiplierToMetersFrom(unit) {
        rel = {
            km: 1000,
            m: 1,
            cm: 0.01,
            mm: 0.001,
            mi: 1609.34,
            yrd: 0.9144,
            ft: 0.3048,
            in: 0.0254
        };
        return rel[unit];
    }

}