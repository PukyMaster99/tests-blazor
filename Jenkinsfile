pipeline {
    agent any
    
    stages {
        stage('Código') {
            steps {
                checkout scm
                echo ''
            }
        }
        
        stage('Compilar y Probar') {
            steps {
                bat '''
                echo "Restaurando dependencias..."
                dotnet restore
                
                echo "Compilando proyecto..."
                dotnet build
                
                echo "Ejecutando pruebas..."
                dotnet test
                '''
            }
        }
    }
    
    post {
        always {
            echo "Pipeline completado"
        }
    }
}