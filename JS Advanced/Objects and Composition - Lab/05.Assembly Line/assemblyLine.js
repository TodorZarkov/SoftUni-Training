'use strict';
function solve() {
    return {
        hasClima: function (car) {
            car['temp'] = 21;
            car['tempSettings'] = 21;
            car['adjustTemp'] = function () {
                if (car.temp < car.tempSettings) {
                    car.temp++;
                } else if (car.temp < car.tempSettings) {
                    car.temp--;
                }
            }
        },

        hasAudio(car) {
            car.currentTrack = {
                name: null,
                artist: null
            }

            car.nowPlaying = function () {
                if (car.currentTrack !== null) {
                    console.log(`Now playing '${car.currentTrack.name}' by ${car.currentTrack.artist}`)
                }
            }

        },

        hasParktronic(car) {
            car.checkDistance = function (distance) {
                if (distance < 0.1) {
                    console.log("Beep! Beep! Beep!");
                } else if (distance < 0.25) {
                    console.log("Beep! Beep!");
                } else if (distance < 0.5) {
                    console.log("Beep!");
                } else {
                    console.log('');
                }
            }
        }
    }
}
