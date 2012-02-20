require 'rake/clean'

# prject variables
DOT_NET_PATH = "#{ENV["SystemRoot"]}\\Microsoft.NET\\Framework\\v4.0.30319"
XUNIT_EXE = "src/packages/xunit.runners.1.9.0.1566/tools/xunit.console.clr4.exe"
SOURCE_PATH = "src"
CONFIG = "Release"

# Tasks
task :default => [:nuget, :compile, :unit_test]

desc "Install packages with nuget"
task :nuget do
    Dir.glob("#{SOURCE_PATH}/**/packages.config").each do |f|
        sh "nuget.exe install #{f} -OutputDirectory #{SOURCE_PATH}/packages"
    end 
end

desc "Build solutions using MSBuild"
task :compile  do  
  solutions = FileList["#{SOURCE_PATH}/**/*.sln"]
  solutions.each do |solution|
    sh "#{DOT_NET_PATH}/msbuild.exe /p:Configuration=#{CONFIG} #{solution}"
  end
end
   
desc "Running unit tests"
task :unit_test do
  Dir.glob("#{SOURCE_PATH}/*.Fixture/bin/#{CONFIG}/*.Fixture.dll").each do |f| 
    sh "#{XUNIT_EXE} #{f}"
  end 
end