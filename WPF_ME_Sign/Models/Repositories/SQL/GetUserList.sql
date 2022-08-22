select user_id,
    user_name,
    department_name,
    email,
    role_name,
    to_char(create_date, 'dd/MM/yyyy') as create_date,
    me_user.status as status
from me_user
    left join me_department on me_user.dept_id = me_department.department_id
    left join me_role on me_user.role_id = me_role.role_id
where me_user.status = 'A'