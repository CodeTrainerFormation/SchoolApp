const url = "https://localhost:7001/classroom"

//GET list of classroom

let myHeaders = new Headers();
myHeaders.append("Accept", "application/json; charset=utf-8");

let myInit = {
    method: "GET",
    headers: myHeaders
};

fetch(new Request(url), myInit)
    .then(function (response) {
        return response.json();
    })
    .then(function (data) {

        for (let i = 0; i < data.length; i++) {
            console.log(data[i]);
        }
    })
    .catch(function (err) {
        console.log(err);
    });


//GET classroom

//let myHeaders = new Headers();
//myHeaders.append("Accept", "application/json; charset=utf-8");

//let myInit = {
//    method: "GET",
//    headers: myHeaders
//};

//fetch(new Request(`${url}/1`), myInit)
//    .then(function (response) {
//        return response.json();
//    })
//    .then(function (data) {
//        console.log(data);
//    })
//    .catch(function (err) {
//        console.log(err);
//    });

//POST

//class Classroom {
//    constructor(classroomid, name, floor, corridor) {
//        this.classroomid = classroomid;
//        this.name = name;
//        this.floor = floor;
//        this.corridor = corridor;
//    }
//}

//let classroom = new Classroom(0, "Salle Scott Guthrie", 2, "Orange");

//let myHeaders = new Headers();
//myHeaders.append("Content-Type", "application/json; charset=utf-8");
//myHeaders.append("Accept", "application/json; charset=utf-8");

//let myInit = {
//    method: "POST",
//    headers: myHeaders,
//    body: JSON.stringify(classroom)
//};

//fetch(new Request(url), myInit)
//    .then(function (response) {
//        return response.json();
//    })
//    .then(function (data) {
//        console.log(data);
//    })
//    .catch(function (err) {
//        console.log(err);
//    });

//PUT

//class Classroom {
//    constructor(classroomid, name, floor, corridor) {
//        this.classroomid = classroomid;
//        this.name = name;
//        this.floor = floor;
//        this.corridor = corridor;
//    }
//}

//let classroom = new Classroom(3, "Salle Scott Guthrie", 2, "Rouge");

//let myHeaders = new Headers();
//myHeaders.append("Content-Type", "application/json; charset=utf-8");

//let myInit = {
//    method: "PUT",
//    headers: myHeaders,
//    body: JSON.stringify(classroom)
//};

//fetch(new Request(`${url}/3`), myInit)
//    .then(function (response) {
//        return response.json();
//    })
//    .then(function (data) {
//        console.log(data);
//    })
//    .catch(function (err) {
//        console.log(err);
//    });


//DELETE classroom

//let myHeaders = new Headers();
//myHeaders.append("Accept", "application/json; charset=utf-8");

//let myInit = {
//    method: "DELETE",
//    headers: myHeaders
//};

//fetch(new Request(`${url}/1`), myInit)
//    .then(function (response) {
//        return response.json();
//    })
//    .then(function (data) {

//        console.log(data);
//    })
//    .catch(function (err) {
//        console.log(err);
//    });