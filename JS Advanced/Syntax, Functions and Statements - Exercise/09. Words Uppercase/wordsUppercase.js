'use strict';
function parsWordsToUpper(text) {
    let txt = String(text);
    const regEx = /\w+/g;
    // let matches = [...text.matchAll(regEx)];
    // let result = '';
    // matches.forEach(x => result += `${String(x[0]).toUpperCase()}, `);
    // result = result.trim();
    // result = result.substring(0, result.length - 1);
    let result = txt.match(regEx).join(', ');
    console.log(result);
}

parsWordsToUpper('   232ff FSD__');