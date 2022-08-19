insert into me_user (
        user_id,
        password,
        user_name,
        dept,
        email,
        role_id,
        create_date
    )
values (
        :userId,
        :password,
        :userName,
        :dept,
        :email,
        :roleId,
        to_date(:create_date, 'ddMMyyyy')
    )