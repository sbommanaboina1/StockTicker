class Student {
    fullName: string;
    constructor(public firstName, public middleName, public lastName) {
        this.fullName = this.firstName + " " + this.middleName + "" + this.lastName;
    }
}

interface Person {
    firstName: string;
    lastName: string;
}

function greetings(person : Person) {
    return "Greetings! " + person.firstName +  ", " + person.lastName + ".";
}


var user = new Student("Srinivas", "Rao", "Bommanaboina");

document.body.innerHTML = greetings(user);