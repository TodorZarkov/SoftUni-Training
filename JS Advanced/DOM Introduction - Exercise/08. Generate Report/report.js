function generateReport() {
    let headings = Array.from(document.querySelectorAll("thead tr th"));
    let rows = Array.from(document.querySelectorAll("tbody tr"));
    
    let checkedColumn = 0;
    let checkedHeadings = [];
    for(let heading of headings){
        let isChecked = heading.getElementsByTagName('input')[0].checked;
        let headValue = heading.getElementsByTagName('input')[0].name;
        if(isChecked){
            checkedHeadings.push([checkedColumn,headValue])
        }
        checkedColumn++;
    }

    
    let result = [];
    let obj = {};
    for(let row of rows){
        for(let heading of checkedHeadings){
            obj[heading[1]] = row.children[heading[0]].textContent;
        }
        result.push(obj);
        obj = {};
    }
    
    document.getElementById("output").textContent = JSON.stringify(result);


}