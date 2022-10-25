function solve(ticketArray, sortBy){
    class Ticket{
        constructor(destination, price, status){
            this.destination = destination;
            this.price = Number(price);
            this.status = status;
        }
    }

    let result = [];
    for(let ticketInfo of ticketArray){
        let ticketData = ticketInfo.split('|');

        let ticket = new Ticket(ticketData[0],ticketData[1],ticketData[2]);
        result.push(ticket);
    }

    if (sortBy === 'destination') {
        result = result.sort((a,b)=>a.destination.localeCompare(b.destination));
    }
    else if (sortBy === 'price') {
        result = result.sort((a,b)=>a.price - b.price);
    }
    else if (sortBy === 'status') {
        result = result.sort((a,b)=>a.status.localeCompare(b.status));
    }

    return result;
}

let slv = solve(['Philadelphia|94.20|available',
'New York City|95.99|available',
'New York City|95.99|sold',
'Boston|126.20|departed'],
'destination');
console.log(JSON.stringify(slv));