'use strict';
//steps, m, km/h
//1min break in every 
function solve(steps, footprint, speedInMpS){
    let distInMeters = steps*footprint;// dist in m
    speedInMpS = speedInMpS*10/36;//[m/s]
    let timeInSeconds = distInMeters/speedInMpS;//[s]
    let timeToRest = 60*Math.floor(distInMeters/500);
    timeInSeconds = timeInSeconds + timeToRest;

    let hours = Math.floor(timeInSeconds/3600);
    let minutes = Math.floor((timeInSeconds%3600)/60);
    let seconds = Math.round((timeInSeconds%3600)%60);

    let formattedHours = hours<10?`0${hours}`:hours;
    let formattedMinutes = minutes<10?`0${minutes}`:minutes;
    let formattedSeconds = seconds<10?`0${seconds}`:seconds;

    console.log(`${formattedHours}:${formattedMinutes}:${formattedSeconds}`)
}
solve(2564, 0.70, 5.5);