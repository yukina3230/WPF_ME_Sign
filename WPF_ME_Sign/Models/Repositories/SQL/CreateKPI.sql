INSERT INTO ME_KPI
  (KPI_ID ,  
  MANPOWER_B,
  CT_B     ,
  EFF_B      ,
  MATERIAL_B ,
  MANPOWER_A ,
  CT_A       ,
  EFF_A      ,
  MATERIAL_A) 
  VALUES
  (seq_me_kpi_id.nextval,    
  :manpower_b,
  :ct_b,     
  :eff_b,      
  :material_b, 
  :manpower_a, 
  :ct_a,       
  :eff_a,      
  :material_a) 
