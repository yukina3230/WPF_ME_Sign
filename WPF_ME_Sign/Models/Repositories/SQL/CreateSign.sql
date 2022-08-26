INSERT INTO
 ME_SIGN(
  SIGN_SERIAL_KEY,
  SIGN_ID,                 
  Department_ID,           
  Form_user_id,           
  Line,                    
  Project_title,           
  Score,                   
  Model,                   
  Processing,              
  Article,                 
  Describe_problem,        
  Improve_problem,         
  Picture_Describe_problem,
  Picture_Improve_problem, 
  Create_User_ID,          
  Create_Date,
  KPI_ID,
  STATUS_SIGN
    )
VALUES(
  seq_me_sign_serial_key.nextval,  
  :sign_id,               
  :department_id,           
  :form_user_id,            
  :line,
  :project_title,           
  :score,                   
  :model,                   
  :processing,              
  :article,                 
  :describe_problem,        
  :improve_problem,         
  :picture_describe_problem,
  :picture_improve_problem, 
  :create_user_id,
  to_date(:create_date, 'ddMMyyyy'),          
  (select max(kpi_id) from me_kpi),
  :status 
  )           
