pipeline {
  agent any
  stages {
    stage('Build') {
      parallel {
        stage('Build') {
          steps {
            echo 'Building'
          }
        }

        stage('') {
          steps {
            sh '''ls >> test_file;  cat test_file


'''
          }
        }

      }
    }

    stage('Test') {
      steps {
        echo 'Testing'
      }
    }

    stage('Deploy') {
      parallel {
        stage('Deploy') {
          steps {
            echo 'Deploying'
          }
        }

        stage('') {
          steps {
            echo 'Hi, i\'m a second deploy branch'
          }
        }

      }
    }

  }
}