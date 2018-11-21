var tmp = 0;
var matchNumber = 0;
var userWins = 0;

var EnougthButtonIsPressed = true;
var StartNewMatchButtonIsPressed = false;
var winerId = 0;
var gameProcess = 0;

function MoreFunction() {
    //if (model.Players[0].IsPlay === false) {
    //    alert("Вы не можете брать карту, нажмите кнопку Enouth");
    //}
    //if (StartNewMatchButtonIsPressed && model.Players[0].IsPlay) {
    //    Step();
    //    SaveData();
    //}
    //if (!StartNewMatchButtonIsPressed) {
    //    alert("Начните матч");
    //}

    Step();
}

function EnougthFunction() {
    if (StartNewMatchButtonIsPressed) {
        userObj.isPlay = false;
        StartNewMatchButtonIsPressed = false;

        alert("ТУТЬ БУДЕТЬ СОХРАНЕНИЕ");

        gameProcess = 1;

        SaveData();
        EnougthButtonIsPressed = true;
        UpdateUI_BeginGame();
        Update();
    }
    if (!StartNewMatchButtonIsPressed) {
        alert("Начните новую игру!");
    }
}

//function Step() {
//    $.ajax({
//        type: 'P',
//        url: pathToStep,
//        success: function (data) {
//            model = data.model;
//        },
//        error: function (data) {
//            alert(data.responseJSON);
//        },
//        async: false
//    });
//}

function NewStep() {
    $.ajax({
        type: 'POST',
        url: pathToStep,
        data: model,
        success: function (data) {
            model = data.model;
        },
        error: function (data) {
            alert(data.responseJSON);
        },
        async: false
    });
}

function StartRound() {
    $.ajax({
        type: 'POST',
        url: pathToStartRound,
        data: model,
        success: function (data) {
            model = data.model;
        },
        error: function (data) {
            alert(data.responseJSON);
        },
        async: false
    });
}

function EndGameValidation() {
    BotStep();
    BotStep();
    BotStep();
    BotStep();

    DillerStep();
    DillerStep();
    DillerStep();
    DillerStep();

    Update();

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

function Update(model) {
    UpdatePlayers(model);
    UpdateContent(model);

    document.getElementById('GamesPlayed').innerHTML = 'Matches played: ' + matchNumber;
    document.getElementById('GamesWon').innerHTML = 'User wins: ' + userWins;
}

function UpdatePlayers(model) {

    //Player update
    for (var entity = 0; entity < model.Players.length; entity++) {
        if (model.Players[entity] === 1) {
            html = '<table><tr>';
            html += '<td>' + model.Players[entity].Name + '</td>';
            html += '</tr>';
            html += '<td>' + 'points: ' + model.Players[entity].CardPoints + '</td>';
            html += '</tr>';
            document.getElementById('playerInfo_'+entity).innerHTML = html;
        }
        if (model.Players[entity] !== 1) {
            var html = '<table><tr>';
            html += '<td>' + 'Username: ' + model.Players[entity].Name + '</td>';
            html += '</tr>';
            html += '<td>' + 'Score: ' + model.Players[entity].Score + '</td>';
            html += '</tr>';
            html += '<td>' + 'Bank: ' + model.Players[entity].Cash + '</td>';
            html += '</tr>';
            html += '<td>' + 'Points: ' + model.Players[entity].CardPoints + '</td>';
            html += '</tr>';
            document.getElementById('playerInfo_' + entity).innerHTML = html;
        }
    }
}

function UpdateContent(model) {

    for (var entity = 0; entity < model.Players.length; entity++) {
        var html = '<table><tr>';
        for (var i = 0; i < model.Players[entity].PlayerCards.length; i++) {
            html += '<td>' + model.Players[entity].PlayerCards[i]['CardName'] + '</td>';
            html += '</tr>';
        }

        document.getElementById('playerContent_' + entity).innerHTML = html;
    }
}

function Step() {
    if (!EnougthButtonIsPressed) {
        NewStep();
    }
    if (EnougthButtonIsPressed) {
        alert("Матч закончен, нажмите START");
    }
}

function StartNewMatch() {
    if (!EnougthButtonIsPressed) {
        alert("Дайте доиграть другим! Нажмите кнопку Enouth");
    }
    if (EnougthButtonIsPressed) {
        StartRound();

        StartNewMatchButtonIsPressed = true;
        EnougthButtonIsPressed = false;
        winerId = 0;
        gameProcess = 0;

        UpdateUI_GameProcess();
        Update(model);
    }
    if (model.Players[0].Score < 100) {
        alert("Вы проиграли все деньги");
    }
    matchNumber++;
    }

function UpdateUI_BeginGame() {
    var html = '<button class="NewMatch-button" onclick="StartNewMatch()"><h3>Start Game</h3></button>';

    document.getElementById('UserButtons').innerHTML = html;
}

function UpdateUI_EndTurn() {
    var html = '<button class="Enougth-button" onclick="EnougthFunction()"><h3>Enougth</h3></button>';

    document.getElementById('UserButtons').innerHTML = html;
}

function UpdateUI_GameProcess() {
    var html = '<button class="More-button" onclick="MoreFunction()"><h3>More</h3></button>';
    html += '<button class="Enougth-button" onclick="EnougthFunction()"><h3>Enougth</h3></button>';

    document.getElementById('UserButtons').innerHTML = html;
}
