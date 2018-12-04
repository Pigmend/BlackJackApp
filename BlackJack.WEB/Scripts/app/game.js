var tmp = 0;
var matchNumber = 0;
var userWins = 0;

var EnougthButtonIsPressed = true;
var StartNewMatchButtonIsPressed = false;
var winerId = 0;
var gameProcess = 0;

function MoreFunction() {
    Step();
}

function EnougthFunction() {
    gameProcess = 1;

    EndRound();

    EndGame(model);
    UpdateUI_BeginGame();
    Update(model);
}

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

function EndRound() {
    $.ajax({
        type: 'POST',
        url: pathToEndRound,
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

function EndGame(model) {
    if (model.Players[0].CardPoints > 21) {
        alert("У вас перебор, вы проиграли!");
    }
    if (model.Players[1].CardPoints > 21 && model.Players[0].CardPoints < 22) {
        alert("У Диллера перебор, вы выиграли!");
        userWins++;
    }
    if (model.Players[0].CardPoints > model.Players[1].CardPoints && model.Players[0].CardPoints < 22 && model.Players[1].CardPoints < 22) {
        alert("Вы выиграли!");
        userWins++;
    }
    if (model.Players[0].CardPoints < model.Players[1].CardPoints && model.Players[0].CardPoints < 22 && model.Players[1].CardPoints < 22) {
        alert("Вы проиграли! :(");
    }
    if (model.Players[0].CardPoints === model.Players[1].CardPoints && model.Players[1].CardPoints < 22 && model.Players[0].CardPoints < 22) {
        alert("Пат! Никто не выиграл");
    }
    if (model.Players[0].CardPoints > 21 && model.Players[1].CardPoints > 21) {
        alert("У всех перебор, никто не выигрывает!");
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
        if (entity === 1) {
            html = '<table><tr>';
            html += '<td>' + model.Players[entity].Name + '</td>';
            html += '</tr>';
            html += '<td>' + 'points: ' + model.Players[entity].CardPoints + '</td>';
            html += '</tr>';
            document.getElementById('playerInfo_'+entity).innerHTML = html;
        }
        if (entity !== 1) {
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
    NewStep();
    Update(model);
}

function StartNewMatch() {
    StartRound();

    StartNewMatchButtonIsPressed = true;
    EnougthButtonIsPressed = false;
    winerId = 0;
    gameProcess = 0;

    UpdateUI_GameProcess();
    Update(model);
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
