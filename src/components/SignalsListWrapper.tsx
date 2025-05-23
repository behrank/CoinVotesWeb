'use client';

import dynamic from 'next/dynamic';

const SignalsList = dynamic(() => import('./SignalsList').then(mod => mod.SignalsList), {
  ssr: false
});

export function SignalsListWrapper() {
  return <SignalsList />;
} 