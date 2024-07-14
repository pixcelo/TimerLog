CREATE TABLE T_StopwatchLogs (
    LogId INT IDENTITY(1,1) PRIMARY KEY,
    ElapsedTime BIGINT NOT NULL, -- 経過時間をミリ秒単位で記録
    LogDate DATETIME NOT NULL -- 記録日時
);