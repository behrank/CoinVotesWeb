import * as React from "react";
import { Button } from "@/components/ui/button";
import { Card, CardHeader, CardTitle, CardDescription } from "@/components/ui/card";
import Image from "next/image";
import { Navbar } from "@/components/Navbar";
import { SignalsListWrapper } from "@/components/SignalsListWrapper";
import { CommunityWrapper } from "@/components/CommunityWrapper";
import Link from "next/link";

export default function Home() {
  return (
    <>
      <Navbar />
      {/* Bottom gradient overlay */}
      <div 
        style={{
          background: 'linear-gradient(180deg, #07070700, #070707)',
          bottom: 0,
          flex: 'none',
          gap: '0px',
          height: '144px',
          left: 0,
          overflow: 'hidden',
          position: 'fixed',
          right: 0,
          zIndex: 1
        }}
      />
      <main 
        className="flex min-h-screen flex-col"
        style={{
          backgroundColor: '#070707'
        }}
      >
        <section 
          className="relative min-h-[600px] w-full py-20"
          style={{
            background: 'linear-gradient(180deg, #070707 0%, rgb(20, 20, 20) 65.2414132882883%, rgb(7, 7, 7) 100%)'
          }}
        >
          <div className="container mx-auto max-w-5xl grid grid-cols-1 items-center gap-12 px-4 lg:grid-cols-2">
            {/* Text Content - Left Side */}
            <div className="flex flex-col items-start justify-center space-y-8 max-w-md">
              <h1 className="text-4xl font-bold text-white md:text-6xl">
                Your Smart Crypto Trading Companion
              </h1>
              <p className="text-lg text-gray-200">
                Get real-time crypto signals, market analysis, and breaking news all in one powerful app. Make informed trading decisions with CoinInsight.
              </p>
              <div className="relative group">
                {/* Glow effect background */}
                <div 
                  className="absolute -inset-1 bg-blue-500 rounded-lg blur-2xl opacity-75 group-hover:opacity-100 transition duration-1000"
                  style={{
                    background: 'linear-gradient(90deg, #4F46E5, #0EA5E9, #4F46E5)',
                    backgroundSize: '200% 200%',
                    animation: 'moveGlow 8s linear infinite'
                  }}
                />
                
                {/* Button */}
                <Button 
                  size="lg" 
                  className="relative text-white"
                  style={{
                    backgroundColor: 'rgb(73, 48, 235)'
                  }}
                >
                  Get Started
                </Button>
              </div>
            </div>

            {/* Image - Right Side */}
            <div className="relative h-[600px] w-full overflow-hidden">
              <Image
                src="/img/landing.png"
                alt="Crypto Trading Dashboard"
                fill
                className="object-contain object-top"
                priority
              />
            </div>
          </div>
        </section>

        {/* Features Section */}
        <section id="features" className="py-20">
          <div className="container mx-auto px-4">
            <div className="text-center mb-16">
              <h2 className="text-5xl font-bold mb-6 text-white">Platform Features</h2>
              <p className="text-xl text-gray-400 max-w-2xl mx-auto">
                Discover the powerful features that make CoinInsight your ultimate crypto trading companion
              </p>
            </div>
            
            <div className="flex flex-col space-y-8 max-w-5xl mx-auto">
              {/* Live Signals */}
              <div>
                <Card 
                  className="p-6" 
                  style={{
                    background: 'linear-gradient(90deg, rgb(26, 26, 26) 0%, rgb(8, 8, 8) 100%)',
                    borderRadius: '28px',
                    borderColor: '#141414',
                  }}
                >
                  <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
                    {/* Left Column - Text Content */}
                    <div>
                      <CardHeader className="px-0">
                        <CardTitle className="text-3xl font-bold mb-4 text-white">Live Signals</CardTitle>
                        <CardDescription className="text-lg text-gray-400">
                          Track cryptocurrencies and catch instant movement changes in advance. Don&apos;t miss potential buying and selling opportunities.
                        </CardDescription>
                      </CardHeader>
                    </div>
                    
                    {/* Right Column - Signals List */}
                    <div className="border-l border-[#141414] pl-6">
                      <SignalsListWrapper />
                    </div>
                  </div>
                </Card>
              </div>

              {/* Community Section */}
              <div>
                <Card 
                  className="p-6"
                  style={{
                    background: 'linear-gradient(90deg, rgb(26, 26, 26) 0%, rgb(8, 8, 8) 100%)',
                    borderRadius: '28px',
                    borderColor: '#141414'
                  }}
                >
                  <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
                    {/* Left Column - Text Content */}
                    <div>
                      <CardHeader className="px-0">
                        <CardTitle className="text-3xl font-bold mb-4 text-white">Community</CardTitle>
                        <CardDescription className="text-lg text-gray-400">
                          Learn our community prediction of crypto currency for upcoming 4, 12 and 24 hours.
                        </CardDescription>
                      </CardHeader>
                    </div>
                    
                    {/* Right Column - Community List */}
                    <div className="border-l border-[#141414] pl-6">
                      <CommunityWrapper />
                    </div>
                  </div>
                </Card>
              </div>
            </div>
          </div>
        </section>

        {/* FAQ Section */}
        <section className="py-20">
          <div className="container mx-auto px-4">
            <div className="text-center mb-16">
              <h2 className="text-5xl font-bold mb-6 text-white">FAQ</h2>
              <p className="text-xl text-gray-400 max-w-2xl mx-auto">
                Find answers to commonly asked questions about CoinInsight&apos;s features and functionality
              </p>
            </div>
            
            <div className="flex flex-col space-y-4 max-w-5xl mx-auto">
              {/* What is CoinInsight */}
              <Card 
                className="p-6"
                style={{
                  backgroundColor: '#141414',
                  borderRadius: '28px',
                  borderColor: '#141414'
                }}
              >
                <div className="space-y-4">
                  <h3 className="text-white font-medium text-xl">What is CoinInsight?</h3>
                  <p className="text-gray-400 leading-relaxed">
                    CoinInsight analyzes the price movements by examining the exchanges where cryptocurrencies are listed. After this analysis, it shares information with you about the direction of the movement. Additionally, it is an application that shares the direction predictions of users based on specific time intervals.
                  </p>
                </div>
              </Card>

              {/* What is a Signal */}
              <Card 
                className="p-6"
                style={{
                  backgroundColor: '#141414',
                  borderRadius: '28px',
                  borderColor: '#141414'
                }}
              >
                <div className="space-y-4">
                  <h3 className="text-white font-medium text-xl">What is a Signal?</h3>
                  <p className="text-gray-400 leading-relaxed">
                    Although it is difficult to make a precise prediction about price movements, our algorithm analyzes specific factors and technical patterns to generate predictions. We communicate these predictions to you as signals. The signals are created only to help you make more informed predictions. It is important to conduct thorough research and consider the risks before investing.
                  </p>
                </div>
              </Card>

              {/* Signal Meaning */}
              <Card 
                className="p-6"
                style={{
                  backgroundColor: '#141414',
                  borderRadius: '28px',
                  borderColor: '#141414'
                }}
              >
                <div className="space-y-4">
                  <h3 className="text-white font-medium text-xl">I have received a signal but I do not know the meaning of it?</h3>
                  <p className="text-gray-400 leading-relaxed">
                    A signal contains two main pieces of information. The first is the price movement (&ldquo;Buy&rdquo; or &ldquo;Sell&rdquo;) and its probability of continuing. In some cases, the algorithm may generate both buy and sell signals in short intervals. This means that, depending on the probability, there is a possibility of horizontal price movement. A high probability indicates high volatility.
                  </p>
                  <p className="text-gray-400 leading-relaxed">
                    The important point to remember here is that these signals are generated to help you understand market movements. We do not recommend making trades based solely on these signals. Do not neglect to perform the necessary technical analyses when trading cryptocurrencies.
                  </p>
                </div>
              </Card>

              {/* Voting Privacy */}
              <Card 
                className="p-6"
                style={{
                  backgroundColor: '#141414',
                  borderRadius: '28px',
                  borderColor: '#141414'
                }}
              >
                <div className="space-y-4">
                  <h3 className="text-white font-medium text-xl">I have concerns about voting. Does my vote related with personal data?</h3>
                  <p className="text-gray-400 leading-relaxed">
                    Your votes are securely stored in our system. We take your privacy seriously and we never share your voting data with any third parties - your predictions and voting patterns remain strictly within the CoinInsight app.
                  </p>
                </div>
              </Card>
            </div>
          </div>
        </section>

        {/* Download Section */}
        <section 
          id="download" 
          className="py-20"
          style={{
            background: 'linear-gradient(180deg, #070707 0%, rgb(20, 20, 20) 65.2414132882883%, rgb(7, 7, 7) 100%)'
          }}
        >
          <div className="container mx-auto px-4">
            <div className="text-center mb-8">
              <h2 className="text-5xl font-bold mb-4 text-white">
                Download
              </h2>
              <p className="text-xl text-gray-400 max-w-2xl mx-auto">
                Get started with CoinInsight on your favorite platform
              </p>
            </div>
            
            <div className="flex flex-col md:flex-row items-center justify-center gap-6 max-w-5xl mx-auto">
              <Link 
                href="https://apps.apple.com/us/app/coininsight/id6476925677" 
                target="_blank"
                className="flex items-center gap-3 px-6 py-3 rounded-xl transition-all duration-300 hover:scale-105"
                style={{
                  background: 'linear-gradient(90deg, rgb(26, 26, 26) 0%, rgb(8, 8, 8) 100%)',
                  border: '1px solid rgba(255, 255, 255, 0.1)'
                }}
              >
                <svg width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
                  <path d="M14.94 5.19A4.38 4.38 0 0 0 16 2a4.38 4.38 0 0 0-3 1.52 4.09 4.09 0 0 0-1 3.09 3.47 3.47 0 0 0 2.94-1.42zm2.52 7.44a4.51 4.51 0 0 1 2.16-3.81 4.66 4.66 0 0 0-3.66-2c-1.56-.16-3 .91-3.83.91-.83 0-2-.89-3.3-.87a4.92 4.92 0 0 0-4.14 2.53C2.93 12.45 4.24 17 6 19.47c.8 1.21 1.8 2.58 3.12 2.53 1.32-.05 1.75-.82 3.28-.82 1.53 0 2 .82 3.3.79 1.3-.03 2.22-1.24 3.06-2.45a11 11 0 0 0 1.38-2.85 4.41 4.41 0 0 1-2.68-4.04z" fill="white"/>
                </svg>
                <div className="flex flex-col">
                  <span className="text-sm text-gray-400">Download on the</span>
                  <span className="text-lg font-semibold text-white">App Store</span>
                </div>
              </Link>

              <Link 
                href="https://play.google.com/store/apps/details?id=com.bemobile.coininsight" 
                target="_blank"
                className="flex items-center gap-3 px-6 py-3 rounded-xl transition-all duration-300 hover:scale-105"
                style={{
                  background: 'linear-gradient(90deg, rgb(26, 26, 26) 0%, rgb(8, 8, 8) 100%)',
                  border: '1px solid rgba(255, 255, 255, 0.1)'
                }}
              >
                <svg width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
                  <path d="M3.609 2.5l8.263 8.264-8.263 8.263a1.914 1.914 0 01-.359-1.207V3.707c0-.47.137-.89.359-1.207zm9.5 9.5l2.789 2.789-10.535 6.11a1.914 1.914 0 01-1.07.172l8.816-9.071zm3.872 2.182l-2.582-1.496 2.582-1.496 2.582 1.496-2.582 1.496zm-1.318-2.789l-2.789-2.789 8.816-9.071a1.914 1.914 0 011.07.172l-7.097 11.688z" fill="white"/>
                </svg>
                <div className="flex flex-col">
                  <span className="text-sm text-gray-400">Get it on</span>
                  <span className="text-lg font-semibold text-white">Google Play</span>
                </div>
              </Link>
            </div>
          </div>
        </section>
      </main>
    </>
  );
}
