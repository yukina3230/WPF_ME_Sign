insert into me_user (
        me_user_id,
        user_id,
        password,
        user_name,
        dept_id,
        email,
        role_id,
        create_date,
        status
    )
values (
        seq_me_user_id.nextval,
        :userId,
        :password,
        :userName,
        :deptId,
        :email,
        :roleId,
        to_date(:create_date, 'ddMMyyyy'),
        :status
    )