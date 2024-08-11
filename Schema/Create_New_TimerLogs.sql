USE TimerLogDB
GO

-- ユーザーマスタ
CREATE TABLE M_Users (
    Id BIGINT IDENTITY(1,1) NOT NULL,
    Name NVARCHAR(64) NOT NULL,
    CONSTRAINT PK_M_Users PRIMARY KEY CLUSTERED 
(
	Id ASC
));
Go

-- タイマータイプマスタ
CREATE TABLE M_TimerTypes (
    Id BIGINT IDENTITY(1,1) NOT NULL,
    Name NVARCHAR(64) NOT NULL,
    CONSTRAINT PK_M_TimerTypes PRIMARY KEY CLUSTERED 
(
	Id ASC
));
Go

-- 旧ストップウォッチログ → タイマーログに変更
CREATE TABLE T_TimerLogs (
    LogId BIGINT IDENTITY(1,1) PRIMARY KEY,
    ElapsedTime BIGINT NOT NULL, -- 経過時間をミリ秒単位で記録
    LogDate DATETIME NOT NULL, -- 記録日時
    UserId BIGINT NOT NULL, -- ユーザーID
    TypeId BIGINT NULL, -- タイプID
);
GO

-- タイマーログビュー
CREATE VIEW V_TimerLogs AS
SELECT
    T.LogId,
    T.ElapsedTime,
	-- 計算や変換処理は出来るだけC#側で行う
    -- 経過時間を分:秒.ミリ秒に変換
    --CAST((T.ElapsedTime / 60000) AS VARCHAR) + ':' + 
    --RIGHT('0' + CAST(((T.ElapsedTime % 60000) / 1000) AS VARCHAR), 2) + '.' + 
    --RIGHT('0' + CAST((T.ElapsedTime % 1000) / 10 AS VARCHAR), 2) AS ElapsedTimeFormatted,
    T.logDate,
    T.userId,
    T.typeId,
    U.Name AS UserName,
    TT.Name AS TimerTypeName
FROM
    T_TimerLogs T
    LEFT JOIN M_Users U ON T.UserId = U.Id
    LEFT JOIN M_TimerTypes TT ON T.TypeId = TT.Id;

GO