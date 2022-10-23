class FootballTeam{
    constructor(clubName, country){
        this.clubName = clubName;
        this.country = country;
    }

    invitePlayers = [];

    newAdditions(footballPlayers){
        for(let player of footballPlayers){
            let data = player.split('/');
            let contains = false;
            for(let playerInList of this.invitePlayers){
                if(playerInList.name === data[0]){
                    if(Number(playerInList.value) < Number(data[2])){
                        playerInList.value = data[2];
                    }
                    contains = true;
                }
            }
            if(!contains){
                this.invitePlayers.push({
                    name:data[0],
                    age:Number(data[1]),
                    value:data[2],
                })
            }
        }

        let result = `You successfully invite ${this.invitePlayers.map(p=>p.name).join(', ')}.`;
        return result;
    }

    signContract(selectedPlayer){
        let data = selectedPlayer.split('/');
        for (let player of this.invitePlayers) {
            let contains = false;
            if(player.name === data[0]){
                contains = true;
                if(Number(player.value) > Number(data[1])){
                    throw new Error(`The manager's offer is not enough to sign a contract with ${player.name}, ${Number(player.value) > Number(data[1])} million more are needed to sign the contract!`);
                }
                player.value = 'Bought';
                break;
            }
            if(!contains){
                throw new Error(`${data[0]} is not invited to the selection list!`)
            }
        }

        return `Congratulations! You sign a contract with ${data[0]} for ${data[1]} million dollars.`
    }


    ageLimit(name, age){
        let player = this.invitePlayers.find(p=>name === p.name);
        if(player = undefined){
            throw new Error(`${name} is not invited to the selection list!`)
        }

        if(player.age <age){
            let difference = this.ageLimit - player.age;
            if(difference < 5){
                return `${name} will sign a contract for ${difference} years with ${clubName} in ${country}!`
            }
            else{
                return `${name} will sign a full 5 years contract for ${clubName} in ${country}!`
            }
        }
        else{
            return `${name} is above age limit!`
        }
    }


    transferWindowResult(){
        let result = "Players list:\n";
        if(this.invitePlayers.length === 0){
            return result;
        }

        let sortedPlayers = this.invitePlayers.sort((a,b)=>a.name.localeCompare(b.name))
        for(let p of sortedPlayers){
            result += `Player ${p.name}-${p.value}\n`
        }
        return result;
    }
}