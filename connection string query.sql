
-- Generate Connection String for Your Database on SSMS or Azure Data Studio
use MyDb;

select
    'data source=' + @@servername +
    ';initial catalog=' + db_name() +
    case type_desc
        when 'WINDOWS_LOGIN' 
            then ';trusted_connection=true'
        else
            ';user id=' + suser_name() + ';password=<<YourPassword>>'
    end
    as ConnectionString
from sys.server_principals
where name = suser_name()

-- Example Output
-- data source=BettPC\SQLEXPRESS;initial catalog=MyDb;trusted_connection=true