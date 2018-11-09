var tmp = 0;
var matchNumber = 0;
var userWins = 0;

var dillerObj = new Entity('dealer', 6, 1);

var EnougthButtonIsPressed = true;
var StartNewMatchButtonIsPressed = false;
var winerId = 0;
var gameProcess = 0;

var cardToPush = {};
function getRandomInt() {
    return Math.floor(Math.random() * 52);
}

function Entity(name, id, role) {

    this.PlayerID = id;
    this.Name = name;
    this.Role = role;

    this.Score = 1000;
    this.Cash = 0;
    this.CardPoints = 0;

    this.Cards = new Array();

    this.isPlay = true;
}

function MoreFunction() {
    if (!userObj.isPlay) {
        alert("Вы не можете брать карту, нажмите кнопку Enouth");
    }
    if (StartNewMatchButtonIsPressed && userObj.isPlay) {
        Step();
        SaveData();
    }
    if (!StartNewMatchButtonIsPressed) {
        alert("Начните матч");
    }
}

function EnougthFunction() {
    if (StartNewMatchButtonIsPressed) {

        userObj.isPlay = false;
        //(END GAME LOGIC) ...
        BotStep();
        BotStep();
        BotStep();
        BotStep();

        DillerStep();
        DillerStep();
        DillerStep();
        DillerStep();

        Update();

        EndGameValidation();
        StartNewMatchButtonIsPressed = false;

        gameProcess = 1;

        SaveData();
        EnougthButtonIsPressed = true;
        Update();
    }
    if (!StartNewMatchButtonIsPressed) {
        alert("Начните новую игру!");
    }
}

function GetCard() {
    $.ajax({
        type: 'GET',
        url: pathToGetCard,
        success: function (data) {
            cardToPush =  data.card;
        },
        error: function (data) {
            alert(data.responseJSON);
        },
        async: false
    });
}

function SaveData() {
    var requestData = new Array();
    requestData.push(userObj);
    requestData.push(dillerObj);
    for (var i = 0; i < botList.length; i++) {
        requestData.push(botList[i]);
    }

    $.ajax({
        type: 'POST',
        url: pathToSave,
        data: {
            Users: requestData,
            WinnerID: winerId,
            GameID: gameID,
            GameProcess: gameProcess 
        },
        error: function (data) {
            alert(data.responseJSON);
        },
        async: false
    });
}

function EndGameValidation() {
    if (dillerObj.CardPoints > 21 && userObj.CardPoints < 22) {
        userObj.Score += userObj.Cash * 2;
        userObj.Cash = 0;
        userWins++;
        winerId = userObj.PlayerID;
        alert("У Диллера перебор, вы выиграли!");
    }
    if (userObj.CardPoints > dillerObj.CardPoints && userObj.CardPoints < 22 && dillerObj.CardPoints < 22) {
        userObj.Score += userObj.Cash * 2;
        userObj.Cash = 0;
        userWins++;
        winerId = userObj.PlayerID;
        alert("Вы выиграли!");
    }
    if (userObj.CardPoints < dillerObj.CardPoints && userObj.CardPoints < 22 && dillerObj.CardPoints < 22) {
        userObj.Cash = 0;
        winerId = dillerObj.PlayerID;
        alert("Вы проиграли! :(");
    }
    if (userObj.CardPoints === dillerObj.CardPoints && dillerObj.CardPoints < 22 && userObj.CardPoints < 22) {
        userObj.Score += userObj.Cash;
        userObj.Cash = 0;
        winerId = 0;
        alert("Пат! Никто не выиграл");
    }
    if (userObj.CardPoints > 21 && dillerObj.CardPoints > 21) {
        userObj.Cash = 0;
        winerId = 0;
        alert("У всех перебор, никто не выигрывает!");
    }
    //Bots Validation
    for (i = 0; i < botList.length; i++) {   
        if (dillerObj.CardPoints > 21 && botList[i].CardPoints < 22) {
            botList[i].Score += botList[i].Cash * 2;
            botList[i].Cash = 0;
        }
        if (botList[i].CardPoints > dillerObj.CardPoints && botList[i].CardPoints < 22 && dillerObj.CardPoints < 22) {
            botList[i].Score += botList[i].Cash * 2;
            botList[i].Cash = 0;
        }
        if (botList[i].CardPoints < dillerObj.CardPoints && botList[i].CardPoints < 22 && dillerObj.CardPoints < 22) {
            botList[i].Cash = 0;
        }
        if (botList[i].CardPoints === dillerObj.CardPoints && botList[i].CardPoints < 22 && dillerObj.CardPoints < 22) {
            botList[i].Score += botList[i].Cash;
            botList[i].Cash = 0;
        }
        if (botList[i].CardPoints > 21 && dillerObj.CardPoints > 21) {
            botList[i].Cash = 0;
        }
    }
}

function Update() {
    UpdatePlayers();
    UpdateContent();

    document.getElementById('GamesPlayed').innerHTML = 'Matches played: ' + matchNumber;
    document.getElementById('GamesWon').innerHTML = 'User wins: ' + userWins;
}

function UpdatePlayers() {

    //Player update
    var html = '<table><tr>';
    html += '<td>' + 'Username: ' + userObj.Name + '</td>';
    html += '</tr>';
    html += '<td>' + 'Score: ' + userObj.Score + '</td>';
    html += '</tr>';
    html += '<td>' + 'Bank: ' + userObj.Cash + '</td>';
    html += '</tr>';
    html += '<td>' + 'Points: ' + userObj.CardPoints + '</td>';
    html += '</tr>';
    document.getElementById('playerInfo').innerHTML = html;

    //Diller update
    html = '<table><tr>';
    html += '<td>' + dillerObj.Name + '</td>';
    html += '</tr>';
    html += '<td>' + 'points: ' + dillerObj.CardPoints + '</td>';
    html += '</tr>';
    document.getElementById('dillerInfo').innerHTML = html;

    //Bots update
    for (var i = 0; i < botList.length; i++) {
        html = '<table><tr>';
        html += '<td>' + 'Username: ' + botList[i].Name + '</td>';
        html += '</tr>';
        html += '<td>' + 'Score: ' + botList[i].Score + '</td>';
        html += '</tr>';
        html += '<td>' + 'Bank: ' + botList[i].Cash + '</td>';
        html += '</tr>';
        html += '<td>' + 'Points: ' + botList[i].CardPoints + '</td>';
        html += '</tr>';
        var botNumber = i + 1;
        document.getElementById('botInfo_' + botNumber).innerHTML = html;
    }
}

function UpdateContent() {

    var html = '<table><tr>';
    for (var i = 0; i < userObj.Cards.length; i++) {
        html += '<td>' + userObj.Cards[i]['CardName'] + '</td>';
        html += '</tr>';
    }

    document.getElementById('playerContent').innerHTML = html;

    html = '<table><tr>';

    for (i = 0; i < dillerObj.Cards.length; i++) {
        html += '<td>' + dillerObj.Cards[i]['CardName'] + '</td>';
        html += '</tr>';
    }

    document.getElementById('dillerContent').innerHTML = html;

    for (i = 0; i < botList.length; i++) {
        html = '<table><tr>';
        for (var j = 0; j < botList[i].Cards.length; j++) {
            html += '<td>' + botList[i].Cards[j]['CardName'] + '</td>';
            html += '</tr>';
        }
        var tmp_botNumber = i + 1;
        document.getElementById('botContent_' + tmp_botNumber).innerHTML = html;
    }
}

function Step() {
    if (!EnougthButtonIsPressed) {
        PlayerStep();
        BotStep();
    }
    if (EnougthButtonIsPressed) {
        alert("Матч закончен, нажмите START");
    }
}

function PlayerStep() {
    if (userObj.CardPoints < 21 && userObj.isPlay) {

        GetCard();
        var tmpCard = cardToPush;
        userObj.Cards.push(tmpCard);

        if (tmpCard['CardNumber'] < 10) {
            userObj.CardPoints += tmpCard['CardNumber'] + 1;
        }
        if (tmpCard['CardNumber'] > 9 && tmpCard['CardNumber'] < 13) {
            userObj.CardPoints += 10;
        }
        if (tmpCard['CardNumber'] === 13) {
            userObj.CardPoints += 11;
        }

        var numberOfAces = 0;
        for (var j = 0; j < userObj.Cards.length; j++) {
            if (userObj.Cards[j]['CardNumber'] === 13) {
                numberOfAces++;
            }
        }
        if (numberOfAces > 1) {
            userObj.CardPoints -= 10;
        }

        if (tmpCard['CardNumber'] === 13 && userObj.CardPoints > 21) {
            userObj.CardPoints -= 10;
        }

        Update();

    }
    if (userObj.points > 21) {
        userObj.isPlay = false;
        alert("У вас перебор! Нажмите Enouth");
    }
    if (userObj.points === 21) {
        userObj.isPlay = false;
        alert("У Вас 21, нажмите кнопку ENOUTH");
    }
    Update();
}

function BotStep() {
    for (var i = 0; i < botList.length; i++) {
        if (botList[i].Score < 100) {
            botList[i].isPlay = false;
        }
        if (botList[i].CardPoints >= 16) {
            botList[i].isPlay = false;
        }
        if (botList[i].isPlay) {
            GetCard();
            var tmpCard = cardToPush;
            botList[i].Cards.push(tmpCard);

            if (tmpCard['CardNumber'] < 10) {
                botList[i].CardPoints += tmpCard['CardNumber'] + 1;
            }
            if (tmpCard['CardNumber'] > 9 && tmpCard['CardNumber'] < 13) {
                botList[i].CardPoints += 10;
            }
            if (tmpCard['CardNumber'] === 13) {
                botList[i].CardPoints += 11;
            }
            var numberOfAces = 0;
            for (var j = 0; j < botList[i].Cards.length; j++) {
                if (botList[i].Cards[j]['CardNumber'] === 13) {
                    numberOfAces++;
                }
            }
            if (numberOfAces > 1) {
                botList[i].CardPoints -= 10;
            }

            if (tmpCard['CardNumber'] === 13 && botList[i].CardPoints > 21) {
                botList[i].CardPoints -= 10;
            }
        }
    }

    Update();
}

function DillerStep() {
    if (dillerObj.isPlay) {
        if (dillerObj.CardPoints < 17) {
            GetCard();
            var tmpCard = cardToPush;
            dillerObj.Cards.push(tmpCard);

            if (tmpCard['CardNumber'] < 10) {
                dillerObj.CardPoints += tmpCard['CardNumber'] + 1;
            }
            if (tmpCard['CardNumber'] >= 10 && tmpCard['CardNumber'] < 13) {
                dillerObj.CardPoints += 10;
            }
            if (tmpCard['CardNumber'] === 13) {
                dillerObj.CardPoints += 11;
            }

            var numberOfAces = 0;
            for (var j = 0; j < dillerObj.Cards.length; j++) {
                if (dillerObj.Cards[j]['CardNumber'] === 13) {
                    numberOfAces++;
                }
            }
            if (numberOfAces > 1) {
                dillerObj.CardPoints -= 10;
            }

            if (tmpCard['CardNumber'] === 13 && dillerObj.CardPoints > 21) {
                dillerObj.CardPoints -= 10;
            }
        }
        if (dillerObj.CardPoints >= 17) {
            dillerObj.isPlay = false;
        }
        Update();
    }
}

function StartNewMatch() {
    if (!EnougthButtonIsPressed) {
        alert("Дайте доиграть другим! Нажмите кнопку Enouth");
    }
    if (EnougthButtonIsPressed) {
        if (userObj.Score > 100) {

            userObj.Score -= 100;
            userObj.Cash = 100;
            userObj.CardPoints = 0;
            userObj.Cards = new Array();
            userObj.isPlay = true;

            dillerObj.CardPoints = 0;
            dillerObj.Cards = new Array();
            dillerObj.isPlay = true;

            document.getElementById('playerContent').innerHTML = null;
            document.getElementById('dillerContent').innerHTML = null;

            for (var i = 0; i < botList.length; i++) {
                var numberOfBot = i + 1;
                document.getElementById('botContent_' + numberOfBot).innerHTML = null;
                botList[i].Score -= 100;
                botList[i].Cash = 100;
                botList[i].CardPoints = 0;
                botList[i].Cards = new Array();
                botList[i].isPlay = true;
            }

            PlayerStep();
            PlayerStep();

            BotStep();
            BotStep();

            DillerStep();

            SaveData();

            StartNewMatchButtonIsPressed = true;
            EnougthButtonIsPressed = false;
            winerId = 0;
            gameProcess = 0;

            Update();
        }
        else if (userObj.score < 100) {
            alert("Вы проиграли все деньги");
        }
    }
    matchNumber++;
}
