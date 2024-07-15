// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.addEventListener('DOMContentLoaded', function () {
    fetchUsers();
    fetchTimerTypes();
});

// ユーザーデータを取得する
async function fetchUsers() {
    try {
        const response = await fetch('https://localhost:7177/api/users');
        if (!response.ok) {
            throw new Error('ユーザーデータの取得に失敗しました。');
        }
        const users = await response.json();
        const radioContainer = document.querySelector('.align-content-center');
        radioContainer.innerHTML = '';
        users.forEach((user, index) => {
            const radioHtml = `
                <div class="form-check w-25">
                    <input class="form-check-input" type="radio" name="flexRadioDefault" id="flexRadioDefault${index}" value="${user.id}" ${index === 0 ? 'checked' : ''}>
                    <label class="form-check-label" for="flexRadioDefault${index}">
                        <p class="p-font">${user.name}</p>
                    </label>
                </div>
            `;
            radioContainer.innerHTML += radioHtml;
        });
    } catch (error) {
        console.error(error);
    }
}

// タイマータイプデータを取得する
async function fetchTimerTypes() {
    try {
        const response = await fetch('https://localhost:7177/api/timertypes');
        if (!response.ok) {
            throw new Error('TimerTypeデータの取得に失敗しました。');
        }
        const timerTypes = await response.json();
        const selectElement = document.getElementById('timerTypeSelect');
        selectElement.innerHTML = '';
        timerTypes.forEach((type) => {
            const option = document.createElement('option');
            option.value = type.id;
            option.textContent = type.name;
            selectElement.appendChild(option);
        });
    } catch (error) {
        console.error(error);
    }
}


(function () {
    let isRunning = false;
    let startTime;
    let elapsedTime = 0;
    let timerInterval;

    function updateTimeDisplay() {
        const now = new Date().getTime();
        const diff = now - startTime + elapsedTime;
        const date = new Date(diff);
        const minutes = String(date.getMinutes()).padStart(2, '0');
        const seconds = String(date.getSeconds()).padStart(2, '0');
        const milliseconds = String(Math.floor(date.getMilliseconds() / 10)).padStart(2, '0');
        document.getElementById('timeDisplay').textContent = `${minutes}:${seconds}.${milliseconds}`;
    }

    function startStopwatch() {
        if (!isRunning) {
            startTime = new Date().getTime();
            timerInterval = setInterval(updateTimeDisplay, 10);
            isRunning = true;
        }
    }

    function stopStopwatch() {
        if (isRunning) {
            clearInterval(timerInterval);
            elapsedTime += new Date().getTime() - startTime;
            isRunning = false;
        }
    }

    function resetStopwatch() {
        if (isRunning) {
            clearInterval(timerInterval);
            isRunning = false;
        }
        elapsedTime = 0;
        document.getElementById('timeDisplay').textContent = '00:00.00';
    }

    document.getElementById('startButton').addEventListener('click', startStopwatch);
    document.getElementById('stopButton').addEventListener('click', stopStopwatch);
    document.getElementById('resetButton').addEventListener('click', resetStopwatch);

    // 保存ボタンクリック時の処理
    document.getElementById('saveButton').addEventListener('click', async function () {
        const selectedUserId = document.querySelector('input[name="flexRadioDefault"]:checked').value;

        const log = {
            ElapsedTime: elapsedTime,
            LogDate: new Date().toISOString(),
            UserId: selectedUserId,
            TypeId: 1
        };

        try {
            const response = await fetch('https://localhost:7177/api/StopwatchLogs', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(log),
            });

            if (!response.ok) {
                throw new Error('サーバーで問題が発生しました。');
            }

            const data = await response.json();
            console.log('保存成功:', data);
            alert('ログが正常に保存されました。');
        } catch (error) {
            console.error('保存失敗:', error);
            alert('ログの保存に失敗しました。');
        }
    });
})();
