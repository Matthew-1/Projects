var cards = ["appleMemory125.jpg",
    "pearMemory125.jpeg",
    "plumMemory125.jpg",
    "cherryMemory125.jpeg",
    "grapefruitMemory125.jpeg",
    "orangeMemory125.jpeg",
    "appleMemory125.jpg",
    "pearMemory125.jpeg",
    "plumMemory125.jpg",
    "cherryMemory125.jpeg",
    "grapefruitMemory125.jpeg",
    "orangeMemory125.jpeg"
];

var scoreCounter = 0;
var tempMem = [];
var arrId = 0;
var sCards = [];
var clickCounter = 0;
var cardId;
var pairRevealed = 0;
var finalScoreNum = 0;

var card = $('.card');


// loop with listener to let it work with ClassName method
for (let i = 0; i < 12; i++) {

    card[i].addEventListener("click", listener, false);

}


//listening if clicked 
function listener(e) {

    //kind of a lock, if there are 2 cards in the memory it doesn t allow to open more
    if (tempMem.length < 3) {

        cCard = String(e.toElement.id);

        clickCounter++;

        revealCard(cCard);

    }
}

//generates random number from 0 to 11
function randomNumber() {

    var random = parseInt(Math.round(Math.random() * 10 + 1));
    var randomNum = parseInt(Math.round(Math.random() * (random + 1)));
    return randomNum;
}

//additional function used when cards need to be shuffled
function move(arr, old_index, new_index) {

    while (old_index < 0) {
        old_index += arr.length;
    }
    while (new_index < 0) {
        new_index += arr.length;
    }
    if (new_index >= arr.length) {
        var k = new_index - arr.length;
        while ((k--) + 1) {
            arr.push(undefined);
        }
    }

    arr.splice(new_index, 0, arr.splice(old_index, 1)[0]);
    return arr;
}

//creates an array of shuffled cards - pack of cards
function cardsArray() {

    for (let i = 0; i < 12; i++) {

        sCards.push(i);

    }

    shuffle();
}

//main shuffling function
function shuffle() {

    for (let i = 0; i < 200; i++) {

        var r_1 = randomNumber();
        var r_2 = randomNumber();

        move(sCards, r_1, r_2);
    }

    return sCards;
}

//it starts the game by calling proper function; it is invoked after 40ms
function gameStart() {

    scoreCounter = 0;
    tempMem = [];
    arrId = 0;
    sCards = [];
    clickCounter = 0;
    cardId;
    pairRevealed = 0;
    finalScoreNum = 0;
    gameFinished = false;

    hideCards();
    cardsArray();

    while (sCards.length > 12) {
        sCards = [];
        cardsArray();

    }

    $(".playAgain").css("visibility", "hidden");
    $(".playAgain").css("position", "absolute");
    $("header").css("visibility", "visible");
    $(".card").css("visibility", "visible");
    $(".scoreNumber").toggleClass("add", false);
    $(".scoreNumber").text(`${scoreCounter}`);
    $(".board").css("visibility", "visible");

}

//it deletes additional class and change averse to reverse
function hideCards() {

    for (let i = 0; i < 12; i++) {

        $("#c" + i).toggleClass("revealed", false);
        $("#c" + i).css("background-image", "url('../LIBRARY/IMG/imgMemory/brain.png')");
    }

    tempMem = [];

}

//hides when there's a pair; clears memory
function hidePair() {

    $("#" + tempMem[1]).css("visibility", "hidden");
    $("#" + tempMem[3]).css("visibility", "hidden");
    $(".scoreNumber").addClass("add");

    pairRevealed++;

    tempMem = [];

    pairRevealed == 6 ? setTimeout(playAgain, 1000) : false;


}


function revealCard(id) {

    if (id.length == 2) {

        arrId = id.charAt(1);

    } else {

        arrId = parseInt(id.charAt(1) + id.charAt(2));
    }

    cardId = $('#' + id);


    if (clickCounter == 1) {

        cardId.css('background-image', `url('../LIBRARY/IMG/imgMemory/${cards[sCards[arrId]]}')`);
        cardId.addClass("revealed");
        memoryIds(cards[sCards[arrId]], id);
        $(".scoreNumber").toggleClass("add", false);


    } else {

        cardId.css('background-image', `url('../LIBRARY/IMG/imgMemory/${cards[sCards[arrId]]}')`);
        cardId.addClass("revealed");
        memoryIds(cards[sCards[arrId]], id); //it passes info to checking function

        if (memoryIds(cards[sCards[arrId]]) == true) {

            setTimeout(hidePair, 1000);

        } else {

            setTimeout(hideCards, 1000);

        }

        scoreCounter++;
        $(".scoreNumber").text(`${scoreCounter}`);
        clickCounter = 0;

    }
}

function memoryIds(checkCard, checkId) {

    tempMem.push(checkCard);
    tempMem.push(checkId);

    if (tempMem[0] === tempMem[2]) {

        return true;

    } else {

        return false;

    }


}

function playAgain() {

    $('ol').append(`<li>${scoreCounter}</li>`)

    $(".board").css("visibility", "hidden");
    $("header").css("visibility", "hidden");
    $(".playAgain").css("position", "static");
    $(".playAgain").css("visibility", "visible");

    $("#finishedScore").html(`${scoreCounter}`);

}



//invokes first function to start domino effect
setTimeout(gameStart, 40);