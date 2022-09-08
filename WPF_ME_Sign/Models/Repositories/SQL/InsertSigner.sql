insert into me_signer (signer_serial_key, sign_id, user_id, create_date)
values (
                seq_me_sign_serial_key.nextval,
                :sign_id,
                :user_id,
                to_date(:create_date, 'dd/MM/yyyy')
        )