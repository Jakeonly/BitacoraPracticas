from selenium import webdriver
from selenium.webdriver.chrome.options import Options
from selenium.webdriver.support.select import Select
from selenium.webdriver.common.by import By
import time

chrome_options = Options()
chrome_options.add_experimental_option(r'excludeSwitches', ['enable-logging'])
chrome_options.add_argument(r"--user-data-dir=C:/Users/crestrepoa/AppData/Local/Google/Chrome/User Data") #e.g. C:/Users/You/AppData/Local/Google/Chrome/User Data
chrome_options.add_argument(r'--profile-directory=Profile 4') #e.g. Profile 3
driver = webdriver.Chrome(executable_path=r'C:/Users/crestrepoa/.wdm/drivers/chromedriver/win32/106.0.5249/chromedriver.exe', chrome_options=chrome_options)

driver.get("https://forms.gle/FVNbhVNETpPU6sih7")
driver.maximize_window()
#INICIAR CAMPOS // PAGINA 1
NombreCompleto = driver.find_element(By.XPATH, "/html/body/div/div[2]/form/div[2]/div/div[2]/div[2]/div/div/div[2]/div/div[1]/div/div[1]/input")
NumDocumento = driver.find_element(By.XPATH, "/html/body/div[1]/div[2]/form/div[2]/div/div[2]/div[4]/div/div/div[2]/div/div[1]/div/div[1]/input")
TelefonoAprendiz = driver.find_element(By.XPATH, "/html/body/div[1]/div[2]/form/div[2]/div/div[2]/div[5]/div/div/div[2]/div/div[1]/div/div[1]/input")
EmailAprendiz = driver.find_element(By.XPATH, "/html/body/div[1]/div[2]/form/div[2]/div/div[2]/div[6]/div/div/div[2]/div/div[1]/div/div[1]/input")
#LLENAR CAMPOS // PAGINA 1
NombreCompleto.send_keys("Cristian David Restrepo Arias")
TipoDocumento = driver.find_element(By.XPATH, "/html/body/div/div[2]/form/div[2]/div/div[2]/div[3]/div/div/div[2]/div/div[1]/div[1]/div[1]").click()
time.sleep(0.2)
TipoDocumentoSelected = driver.find_element(By.XPATH, "/html/body/div/div[2]/form/div[2]/div/div[2]/div[3]/div/div/div[2]/div/div[2]/div[4]").click()
time.sleep(0.2)
NumDocumento.send_keys("1000645300")
TelefonoAprendiz.send_keys("3193683526")
EmailAprendiz.send_keys("cdrestrepo00@misena.edu.co")
BotonSiguiente1 = driver.find_element(By.XPATH, "/html/body/div/div[2]/form/div[2]/div/div[3]/div[1]/div[1]/div/span").click()

#LLENAR CAMPOS // PAGINA 2
CadenaFormacion = driver.find_element(By.XPATH, "/html/body/div/div[2]/form/div[2]/div/div[2]/div[2]/div/div/div[2]/div/div[1]/div[1]/div[1]").click()
time.sleep(0.2)
CadenaFormacionSelected = driver.find_element(By.XPATH, "/html/body/div/div[2]/form/div[2]/div/div[2]/div[2]/div/div/div[2]/div/div[2]/div[6]").click()
time.sleep(0.2)
BotonSiguiente2 = driver.find_element(By.XPATH, "/html/body/div/div[2]/form/div[2]/div/div[3]/div[1]/div[1]/div[2]/span").click()

#LLENAR CAMPOS // PAGINA 3
ProgramaFormacion = driver.find_element(By.XPATH, "/html/body/div/div[2]/form/div[2]/div/div[2]/div[2]/div/div/div[2]/div/div/span/div/div[1]/label/div/div[1]/div/div[3]/div").click()
time.sleep(0.2)
BotonSiguiente3 = driver.find_element(By.XPATH, "/html/body/div/div[2]/form/div[2]/div/div[3]/div[1]/div[1]/div[2]/span").click()

#INICIAR CAMPOS // PAGINA 4
FichaPrograma = driver.find_element(By.XPATH, "/html/body/div/div[2]/form/div[2]/div/div[2]/div[2]/div/div/div[2]/div/div[1]/div/div[1]/input")
#SELECCIONAR CAMPOS // PAGINA 4
FichaPrograma.send_keys("2255302")
EtapaPractica = driver.find_element(By.XPATH, "/html/body/div/div[2]/form/div[2]/div/div[2]/div[3]/div/div/div[2]/div/div/span/div/div[1]/label/div/div[1]/div/div[3]/div").click()
Instructor = driver.find_element(By.XPATH, "/html/body/div/div[2]/form/div[2]/div/div[2]/div[4]/div/div/div[2]/div/div[1]/div[1]/div[1]").click()
time.sleep(0.2)
InstructorSelected = driver.find_element(By.XPATH, "/html/body/div/div[2]/form/div[2]/div/div[2]/div[4]/div/div/div[2]/div/div[2]/div[11]").click()
time.sleep(0.2)
BotonSiguiente4 = driver.find_element(By.XPATH, "/html/body/div/div[2]/form/div[2]/div/div[3]/div[1]/div[1]/div[2]/span").click()

#INICIAR CAMPOS // PAGINA 5
NombreEmpresa = driver.find_element(By.XPATH, "/html/body/div/div[2]/form/div[2]/div/div[2]/div[2]/div/div/div[2]/div/div[1]/div/div[1]/input")
Direccion = driver.find_element(By.XPATH, "/html/body/div/div[2]/form/div[2]/div/div[2]/div[3]/div/div/div[2]/div/div[1]/div[2]/textarea")
Coformador = driver.find_element(By.XPATH, "/html/body/div/div[2]/form/div[2]/div/div[2]/div[4]/div/div/div[2]/div/div[1]/div/div[1]/input")
Cargo = driver.find_element(By.XPATH, "/html/body/div/div[2]/form/div[2]/div/div[2]/div[5]/div/div/div[2]/div/div[1]/div/div[1]/input")
TelefonoCoformador = driver.find_element(By.XPATH, "/html/body/div/div[2]/form/div[2]/div/div[2]/div[6]/div/div/div[2]/div/div[1]/div/div[1]/input")
EmailCoformador = driver.find_element(By.XPATH, "/html/body/div/div[2]/form/div[2]/div/div[2]/div[7]/div/div/div[2]/div/div[1]/div/div[1]/input")
Actividades = driver.find_element(By.XPATH, "/html/body/div/div[2]/form/div[2]/div/div[2]/div[8]/div/div/div[2]/div/div[1]/div[2]/textarea")
SolucionAplicada = driver.find_element(By.XPATH, "/html/body/div/div[2]/form/div[2]/div/div[2]/div[11]/div/div/div[2]/div/div[1]/div[2]/textarea")
#LLENAR CAMPOS // PAGINA 5
NombreEmpresa.send_keys("Visionamos Tecnología")
Direccion.send_keys("Carrera 43 A No. 31-159 Ed. Gruval, Piso 2 Av. El Poblado Medellín – Colombia")
Coformador.send_keys("Juan Camilo Bedoya Martinez")
Cargo.send_keys("Líder de Desarrollo")
TelefonoCoformador.send_keys("3113135295")
EmailCoformador.send_keys("jbedoya@visionamos.com")
#INICIO PERSONALIZAR
Actividades.send_keys("Desarrollo de aplicativos en función de los requerimientos propuestos")
#FIN PERSONALIZAR
AcordeCompetencia = driver.find_element(By.XPATH, "/html/body/div/div[2]/form/div[2]/div/div[2]/div[9]/div/div/div[2]/div/div[1]/div[1]/div[1]").click()
time.sleep(0.2)
AcordeCompetenciaSelected = driver.find_element(By.XPATH, "/html/body/div/div[2]/form/div[2]/div/div[2]/div[9]/div/div/div[2]/div/div[2]/div[3]").click()
time.sleep(0.2)
Problema = driver.find_element(By.XPATH, "/html/body/div/div[2]/form/div[2]/div/div[2]/div[10]/div/div/div[2]/div/div[1]/div[1]/div[1]").click()
time.sleep(0.2)
ProblemaSelected = driver.find_element(By.XPATH, "/html/body/div/div[2]/form/div[2]/div/div[2]/div[10]/div/div/div[2]/div/div[2]/div[3]").click()
time.sleep(0.2)
SolucionAplicada.send_keys("Problema: necesidad de vistas para el área de proveedores, Solución: desarrollo de estos requerimientos, con vistas: Gestion de proveedor y reglas de proveedor")
BotonSiguiente5 = driver.find_element(By.XPATH, "/html/body/div/div[2]/form/div[2]/div/div[3]/div[1]/div[1]/div[2]/span").click()

#INICIAR CAMPOS // PAGINA 6
Dificultades = driver.find_element(By.XPATH, "/html/body/div/div[2]/form/div[2]/div/div[2]/div[2]/div/div/div[2]/div/div[1]/div[2]/textarea")
#LLENAR CAMPOS // PAGINA 6
Dificultades.send_keys("El sistema metro")
Conocimientos = driver.find_element(By.XPATH, "/html/body/div/div[2]/form/div[2]/div/div[2]/div[3]/div/div/div[2]/div/div[1]/div[1]/div[1]").click()
time.sleep(0.2)
ConocimientosSelected = driver.find_element(By.XPATH, "/html/body/div/div[2]/form/div[2]/div/div[2]/div[3]/div/div/div[2]/div/div[2]/div[3]").click()
time.sleep(0.2)
NovedadInstructor = driver.find_element(By.XPATH, "/html/body/div/div[2]/form/div[2]/div/div[2]/div[4]/div/div/div[2]/div/div[1]/div[1]/div[1]").click()
time.sleep(0.2)
NovedadInstructorSelected = driver.find_element(By.XPATH, "/html/body/div/div[2]/form/div[2]/div/div[2]/div[4]/div/div/div[2]/div/div[2]/div[3]").click()
time.sleep(0.2)
BotonSiguiente6 = driver.find_element(By.XPATH, "/html/body/div/div[2]/form/div[2]/div/div[3]/div[1]/div[1]/div[2]/span").click()

#FINAL CUESTIONARIO
BotonEnviar = driver.find_element(By.XPATH, "/html/body/div/div[2]/form/div[2]/div/div[3]/div[1]/div[1]/div[2]/span").click()



