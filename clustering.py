import sys
import os
import time
import numpy as np
np.set_printoptions(threshold=sys.maxsize)
properties=sys.argv[1]
n_clusters=int(properties[-2:])
def check_number(entry):
    for item in entry:
        try:
            float(item)
        except:
            return False
        return True

def nearest_cluster(coords):
    distances=[]
    for com in cluster:
        distances.append(np.sqrt(np.sum((coords-com)**2)))
    closest=np.argmin(distances)
    #distance=distances[closest]

    return closest

iterations=100

file=open('D:\\documents\\search4solutions\\programtest\\exoplanets_data.csv','r')
#file=open('/mnt/d/documents/search4solutions/programtest/exoplanets_data.csv','r')
text=file.read()

lines=text.splitlines()
data=[]
for line in lines:
    data.append(line.split(','))
data=np.array(data)
used_data=[]
for i in range(len(data[0])):
    prop=data[0,i]
    if prop in properties:
        used_data.append(data[1:,i])
used_data=np.array(used_data)

final_data=[]
for i in range(len(used_data[0])):
    entry=used_data[:,i]
    try: final_data.append([float(number) for number in entry])
    except: continue
final_data=np.array(final_data)
for i in range(len(final_data[0])):
    final_data[:,i]=(final_data[:,i]-np.min(final_data[:,i]))/(np.max(final_data[:,i])-np.min(final_data[:,i]))

np.random.seed(int(time.time()))
cluster=[]
for i in range(n_clusters):
    cluster.append(np.random.rand(len(final_data[0])))
cluster=np.array(cluster)
member_of=np.zeros(len(final_data))
for j in range(iterations):
    #calculate nearest cluster center for eacht datapoint
    for i in range(len(final_data)):

        member_of[i]=nearest_cluster(final_data[i])
    #calculate new cluster centers
    for i in range(len(cluster)):
        if(np.sum(final_data[member_of==i])==0.0):
            continue
        cluster[i]=np.sum(final_data[member_of==i],axis=0)/len(final_data[member_of==i])
#for i in range(n_clusters):
#    print(len(member_of[member_of==i]))
#print(member_of)
np.savetxt("cluster.txt", member_of, fmt="%s")
