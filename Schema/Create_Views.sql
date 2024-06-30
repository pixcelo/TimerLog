-- タイマーログビュー
CREATE VIEW V_TimerLog AS
SELECT
    T.Id,
    T.StartAt,
    T.EndAt,
    -- 経過時間
    DATEDIFF(MINUTE, T.StartAt, T.EndAt) AS ElapsedMinutes,
    U.Name AS UserName,
    TT.Name AS TimerTypeName
FROM
    T_TimerLog T
    LEFT JOIN M_User U ON T.UserId = U.Id
    LEFT JOIN M_TimerType TT ON T.TypeId = TT.Id;

GO