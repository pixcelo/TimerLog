-- ログインの作成 (SQL Server 認証)
CREATE LOGIN tek WITH PASSWORD = 'StrongPassword123!';

-- データベースを指定
USE TR;

-- ユーザーの作成
CREATE USER tek FOR LOGIN tek;

-- 特定のテーブルに対する権限付与（オプション）
GRANT SELECT, INSERT, UPDATE, DELETE ON dbo.T_StopwatchLogs TO tek;
GRANT SELECT ON dbo.M_TimerType TO tek;
GRANT SELECT ON dbo.M_Users TO tek;