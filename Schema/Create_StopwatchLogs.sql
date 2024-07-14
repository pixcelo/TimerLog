CREATE TABLE T_StopwatchLogs (
    LogId BIGINT IDENTITY(1,1) PRIMARY KEY,
    ElapsedTime BIGINT NOT NULL, -- 経過時間をミリ秒単位で記録
    LogDate DATETIME NOT NULL, -- 記録日時
    UserId BIGINT NOT NULL, -- ユーザーID
    TypeId BIGINT NULL, -- タイプID
);

-- ストップウォッチログビュー
CREATE VIEW V_StopwatchLogs AS
SELECT
    T.LogId,
    T.ElapsedTime,
    -- 経過時間を分:秒.ミリ秒に変換
    CAST((T.ElapsedTime / 60000) AS VARCHAR) + ':' + 
    RIGHT('0' + CAST(((T.ElapsedTime % 60000) / 1000) AS VARCHAR), 2) + '.' + 
    RIGHT('0' + CAST((T.ElapsedTime % 1000) / 10 AS VARCHAR), 2) AS ElapsedTimeFormatted,
    T.logDate,
    T.userId,
    T.typeId,
    U.Name AS UserName,
    TT.Name AS TimerTypeName
FROM
    T_StopwatchLogs T
    LEFT JOIN M_Users U ON T.UserId = U.Id
    LEFT JOIN M_TimerType TT ON T.TypeId = TT.Id;

GO