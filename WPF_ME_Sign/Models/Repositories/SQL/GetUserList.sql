select user_id,
    user_name,
    (select dept_name from me_department where dept_name = dept_id) as dept_name,
    email,
    (select role_name from me_department where role_name = role_id) as role_name,
    to_char(create_date, 'dd/MM/yyyy') as create_date,
    status
from me_user
where status = 'A'