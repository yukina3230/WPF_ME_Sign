select user_id,
    user_name,
    dept,
    email,
    role_id,
    to_char(create_date, 'dd/MM/yyyy') as create_date,
    status
from me_user
where status = 'A'