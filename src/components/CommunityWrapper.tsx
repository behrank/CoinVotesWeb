'use client';

import dynamic from 'next/dynamic';

const Community = dynamic(() => import('./Community').then(mod => mod.Community), {
  ssr: false
});

export function CommunityWrapper() {
  return <Community />;
} 