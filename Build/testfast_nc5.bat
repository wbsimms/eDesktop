@echo off

REM msbuild EHRProfiler.xml /t:SimianReport;BuildCommon;Coverage;CoverageReport

REM For NCover 5.... when they fix it.
msbuild eDesktop.xml /t:SimianReport;BuildCommon;AddEnableCoverage;TestOnly;GetCoverageReport