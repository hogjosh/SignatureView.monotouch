XBUILD=/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild
MONOBUILD=/Library/Frameworks/Mono.Framework/Commands/xbuild
BTOUCH=/Developer/MonoTouch/usr/bin/btouch
ROOT=.
XCODE_PROJECT_ROOT=$(ROOT)/SignatureView.monotouch
XCODE_PROJECT=$(XCODE_PROJECT_ROOT)/SignatureView.monotouch.xcodeproj
XCODE_TARGET=SignatureView.monotouch
MONO_PROJECT_ROOT=$(ROOT)/SignatureView.binding
MONO_PROJECT=$(MONO_PROJECT_ROOT)/SignatureView.binding.csproj

all: clean SignatureView.dll

libSignatureView.monotouch-i386.a:
	$(XBUILD) -project $(XCODE_PROJECT) -target $(XCODE_TARGET) -sdk iphonesimulator -configuration Release clean build
	-mv $(XCODE_PROJECT_ROOT)/build/Release-iphonesimulator/lib$(XCODE_TARGET).a $@

libSignatureView.monotouch-ios.a:
	$(XBUILD) -project $(XCODE_PROJECT) -target $(XCODE_TARGET) -sdk iphoneos -configuration Release clean build
	-mv $(XCODE_PROJECT_ROOT)/build/Release-iphoneos/lib$(XCODE_TARGET).a $@

libSignatureView.monotouch.a: libSignatureView.monotouch-i386.a libSignatureView.monotouch-ios.a
	lipo -create -output $@ $^

SignatureView.dll: libSignatureView.monotouch.a
	$(MONOBUILD) /p:Configuration=Release $(MONO_PROJECT)
	-mv $(MONO_PROJECT_ROOT)/bin/Release/SignatureView.dll $(ROOT)

clean:
	-rm -rf build *.a *.dll *.mdb
