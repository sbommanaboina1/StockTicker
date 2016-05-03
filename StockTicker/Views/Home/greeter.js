var Student = (function () {
    function Student(firstName, middleName, lastName) {
        this.firstName = firstName;
        this.middleName = middleName;
        this.lastName = lastName;
        this.fullName = this.firstName + " " + this.middleName + "" + this.lastName;
    }
    return Student;
}());
function greetings(person) {
    return "Greetings! " + person.firstName + ", " + person.lastName + ".";
}
var user = new Student("Srinivas", "Rao", "Bommanaboina");
document.body.innerHTML = greetings(user);
//# sourceMappingURL=greeter.js.map