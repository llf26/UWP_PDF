function print(jsonString) {
    var data = JSON.parse(jsonString);
    var doc = new jsPDF();
    doc.text('Hello ' + data.name, 10, 10);
    doc.text('Hi shelby',20,20);
    doc.circle(50, 50, 50);
    var pdfresult = doc.output(); 
    document.getElementById('myDiv').innerText = 'hello'; 

    return pdfresult;
}