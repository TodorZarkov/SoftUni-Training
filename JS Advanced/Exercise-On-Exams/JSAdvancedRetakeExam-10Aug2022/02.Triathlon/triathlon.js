class Triathlon {
    constructor(competitionName) {
        this.competitionName = competitionName;
        this.participants = {};
        this.listOfFinalists = [];
    }


    addParticipant(participantName, participantGender) {
        if (this._isPresent(participantName)) {
            return `${participantName} has already been added to the list`
        }

        this.participants[participantName] = participantGender;
        return `A new participant has been added - ${participantName}`;
    }

    completeness(participantName, condition) {
        if (!this._isPresent(participantName)) {
            throw new Error(`${participantName} is not in the current participants list`);
        }

        if (condition < 30) {
            throw new Error(`${participantName} is not well prepared and cannot finish any discipline`)
        }

        let canComplete = condition / 30;
        if (canComplete < 3) {
            return `${participantName} could only complete ${Math.floor(canComplete)} of the disciplines`
        }

        let participantGender = this.participants[participantName]
        this.listOfFinalists.push({ participantName, participantGender })
        delete this.participants[participantName];

        return `Congratulations, ${participantName} finished the whole competition`
    }

    rewarding(participantName) {
        if (!this.listOfFinalists.find(f => f.participantName === participantName)) {
            return `${participantName} is not in the current finalists list`
        }

        return `${participantName} was rewarded with a trophy for his performance`
    }

    showRecord(criteria) {
        if(this.listOfFinalists.length === 0) {
            return `There are no finalists in this competition`;
        }


        if(criteria !== "all") {
            let filtered = this.listOfFinalists.filter(f=>f.participantGender === criteria);
            if(filtered.length === 0) {
                return `There are no ${criteria}'s that finished the competition`
            }
            return `${filtered[0].participantName} is the first ${criteria} that finished the ${this.competitionName} triathlon`
        } else {
            let result = `List of all ${this.competitionName} finalists:\n`;
            result += this.listOfFinalists
            .map(f=>f.participantName)
            .sort((a,b) => a.localeCompare(b))
            .join("\n");

            return result;
        }
    }



    _isPresent(participantName) {
        if (this.participants.hasOwnProperty(participantName)) {
            return true
        }
        return false;
    }
}