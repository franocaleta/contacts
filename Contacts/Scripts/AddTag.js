
var counter = 1;
var limit = 8;
function addInput(divName){
    if (counter == limit)  {
        alert("You have reached the limit of adding " + counter + " inputs");
    }
    else {
        var newdiv = document.createElement('div');
        newdiv.innerHTML = "Tag " + (counter + 1) + " <br><input type='text'  name='myInputs[]'><br><br>";
        document.getElementById(divName).appendChild(newdiv);
        counter++;
    }
}

