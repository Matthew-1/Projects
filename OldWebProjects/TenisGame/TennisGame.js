const canv = document.getElementById('canvas1');
const ctx = canv.getContext('2d');

canv.width = 1000;
canv.height = 500;

const canvasWidth = canv.width;
const canvasHeight = canv.height;

const ballSize = 20;
const paddelHeight = 100;
const paddelWidth = 20;
const playerX = 70;
const aiX = 910;

var playerY = 200;
var aiY = 200;
const lineWidth = 6;
const lineHeight = 16;
const topCanvas = canv.offsetTop;


let ballX = (canvasWidth / 2) - (ballSize / 2);
let ballY = (canvasHeight / 2) - (ballSize / 2);

let ballSpeedX = Math.random() * 20 - 10;
let ballSpeedY = Math.random() * 20 - 10;

ctx.fillStyle = "#56DE00"; //skyblue
ctx.fillRect(0, 0, canvasWidth, canvasHeight);


ctx.fillStyle = "#B30000"; //green
ctx.fillRect(playerX, playerY, paddelWidth, paddelHeight);

ctx.fillStyle = "#333333"; //blue
ctx.fillRect(aiX, aiY, paddelWidth, paddelHeight);


var isFirstGame = true;
var soloGameId;
var doubleGameId;
var singleDoubleMode;
var pointsPlayer_1 = 0;
var pointsPlayer_2 = 0;
var canClickOnCtxField;

for (let linePosition = 20; linePosition < 500; linePosition += 30) {

    ctx.fillStyle = "white";
    ctx.fillRect(canvasWidth / 2 - lineWidth / 2, linePosition, lineWidth, lineHeight);
}

ctx.fillStyle = "grey"; //gray #595959
ctx.fillRect(ballX, ballY, ballSize, ballSize);



$('#single').prop("checked", true);


document.getElementById('form').addEventListener('click', function(e) {

    singleDoubleMode = e.toElement.id;

    if (singleDoubleMode == "single" || singleDoubleMode == "singleMode") {

        $('#single').prop("checked", true);
        $('#double').prop("checked", false);
    }

    if (singleDoubleMode == "double" || singleDoubleMode == "doubleMode") {

        $('#double').prop("checked", true);
        $('#single').prop("checked", false);
    }

});



function START() {

    if (isFirstGame) {
        startAll();
    } else {
        resetAll();
        startAll();
    }


}




function aiPosition() {

    let middlePaddelAiY = aiY + paddelHeight / 2;

    let middleBallY = ballY + ballSize / 2;
    let middleBallX = ballX + ballSize / 2;


    if (middleBallX > 500) {

        if (middlePaddelAiY - middleBallY > 200) {

            aiY -= 40;

        } else if (middlePaddelAiY - middleBallY > 50) {

            aiY -= 25;

        } else if (middlePaddelAiY - middleBallY < -200) {

            aiY += 40;

        } else if (middlePaddelAiY - middleBallY < -50) {

            aiY += 25;

        }

    }
}



function positionOfPlayer_1(e) {

    playerY = e.clientY - topCanvas + paddelHeight / 2;

    if (playerY >= canvasHeight - paddelHeight) {

        playerY = canvasHeight - paddelHeight;
    }

    if (playerY <= 0) {

        playerY = 0;
    }
}

function positionOfPlayer_2(event) {
    console.log(aiY);

    const key = event.keyCode;

    if (key === 38) {

        aiY -= 5;
    }

    if (key === 40) {

        aiY += 5;
    }


    if (aiY >= canvasHeight - paddelHeight) {

        aiY = canvasHeight - paddelHeight;
    }

    if (aiY <= 0) {

        aiY = 0;
    }

}

window.addEventListener("keydown", function(e) {
    // space, page up, page down and arrow keys:
    if ([32, 33, 34, 37, 38, 39, 40].indexOf(e.keyCode) > -1) {
        e.preventDefault();
    }
}, false);

function speedUpBall() {



    if (ballSpeedX > 0 && ballSpeedX < 25) {

        ballSpeedX += .1;

    } else if (ballSpeedX < 0 && ballSpeedX > -25) {

        ballSpeedX -= .1;

    }

    if (ballSpeedY > 0 && ballSpeedY < 25) {

        ballSpeedY += .1;

    } else if (ballSpeedY < 0 && ballSpeedY > -25) {

        ballSpeedY -= .1;



    }
}

function table() {


    ctx.fillStyle = "#56DE00";
    ctx.fillRect(0, 0, canvasWidth, canvasHeight);

    for (let linePosition = 20; linePosition < 500; linePosition += 30) {

        ctx.fillStyle = "white";
        ctx.fillRect(canvasWidth / 2 - lineWidth / 2, linePosition, lineWidth, lineHeight);
    }

}




function tennisBall() {

    ctx.fillStyle = "grey";
    ctx.fillRect(ballX, ballY, ballSize, ballSize);

    ballX += ballSpeedX;
    ballY += ballSpeedY;

    if (ballY <= 0 || ballY + ballSize >= canvasHeight) {

        ballSpeedY = -ballSpeedY;
        speedUpBall();
    }

    if (ballX <= 0 || ballX + ballSize >= canvasWidth) {

        ballSpeedX = -ballSpeedX;
        speedUpBall();
    }



    let middlePaddelPlayerX = playerX + paddelWidth / 2;
    let middlePaddelPlayerY = playerY + paddelHeight / 2;

    let middlePaddelAiX = aiX + paddelWidth / 2;
    let middlePaddelAiY = aiY + paddelHeight / 2;

    let middleBallY = ballY + ballSize / 2;
    let middleBallX = ballX + ballSize / 2;

    if (Math.abs(middleBallX - middlePaddelPlayerX) <= paddelWidth / 2) {

        if (Math.abs(middleBallY - middlePaddelPlayerY) <= paddelHeight / 2) {

            ballSpeedX = -ballSpeedX;
        }
    }

    if (Math.abs(middlePaddelAiX - middleBallX) <= paddelWidth / 2) {

        if (Math.abs(middlePaddelAiY - middleBallY) <= paddelHeight / 2) {

            ballSpeedX = -ballSpeedX;
        }
    }

}

function playerReal() {

    ctx.fillStyle = "#B30000";
    ctx.fillRect(playerX, playerY, paddelWidth, paddelHeight);
    console.log("");
}

function playerAi() {

    ctx.fillStyle = "#333333";
    ctx.fillRect(aiX, aiY, paddelWidth, paddelHeight);
}


function soloGame() {

    table();
    tennisBall();
    playerReal();
    playerAi();
    aiPosition();
    scores();
}


function doubleGame() {

    table();
    tennisBall();
    playerReal();
    playerAi();
    scores();

}



function scores() {


    let p1 = $("#playerOne");
    let p2 = $("#playerTwo");



    p1.text(`Player one: ${pointsPlayer_1}`);
    p2.text(`Player two: ${pointsPlayer_2}`);


    canv.addEventListener('click', function() {

        if (canClickOnCtxField == true) {
            if ((ballX = (canvasWidth / 2) - (ballSize / 2)) && (ballY = (canvasHeight / 2) - (ballSize / 2))) {


                ballSpeedX = Math.random() * 20 - 10;
                ballSpeedY = Math.random() * 20 - 10;

            }

            canClickOnCtxField = false;

        }

    });

    if (ballX <= 0) {

        ballX = (canvasWidth / 2) - (ballSize / 2);
        ballY = (canvasHeight / 2) - (ballSize / 2);

        ballSpeedX = 0;
        ballSpeedY = 0;

        pointsPlayer_2 += 1;
        canClickOnCtxField = true;
    }

    if (ballX + ballSize >= canvasWidth) {

        ballX = (canvasWidth / 2) - (ballSize / 2);
        ballY = (canvasHeight / 2) - (ballSize / 2);

        ballSpeedX = 0;
        ballSpeedY = 0;

        pointsPlayer_1 += 1;
        canClickOnCtxField = true;
    }
}

function resetAll() {
    clearInterval(soloGameId);
    clearInterval(doubleGameId);
    console.log("resetAll");



    playerY = 200;
    aiY = 200;
    ballX = (canvasWidth / 2) - (ballSize / 2);
    ballY = (canvasHeight / 2) - (ballSize / 2);

    ballSpeedX = 0;
    ballSpeedY = 0;

    pointsPlayer_1 = 0;
    pointsPlayer_2 = 0;

    canClickOnCtxField = true;

    table();
    playerReal();
    playerAi();
    aiPosition();


}

function startAll() {
    isFirstGame = false;
    $("#playButton").text("NEW GAME");

    if (document.getElementById("single").checked == true) {

        canv.addEventListener('mousemove', positionOfPlayer_1);
        soloGameId = setInterval(soloGame, 1000 / 100);
        console.log("sologame! yolo!");
    }

    if (document.getElementById("double").checked == true) {

        canv.addEventListener('mousemove', positionOfPlayer_1);
        document.onkeydown = function(event) {

            const key = event.keyCode;

            if (key === 38) {

                aiY -= 50;
            }

            if (key === 40) {

                aiY += 50;
            }


            if (aiY >= canvasHeight - paddelHeight) {

                aiY = canvasHeight - paddelHeight;
            }

            if (aiY <= 0) {

                aiY = 0;
            }

        }
        doubleGameId = setInterval(doubleGame, 1000 / 100);

    }
}